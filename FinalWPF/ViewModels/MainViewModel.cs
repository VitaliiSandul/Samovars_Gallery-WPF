using FinalWPF.Infrastructure;
using FinalWPF.Views;
using MVVMFinalWPF.BLL.DTO;
using MVVMFinalWPF.BLL.Infrastructure;
using MVVMFinalWPF.BLL.Interfaces;
using MVVMFinalWPF.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalWPF.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged
    {
        private ObservableCollection<SamovarDTO> samovars;        
        private SamovarDTO selectedSamovar;
        
        private IService<SamovarDTO> service;
        
        private ProgramConfigJSON programConfigJSON;        
        private ProgramConfig config;
        private Dictionary<string, string> language;

        #region Commands
        public ICommand SortCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand ChangeLanguageCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        #endregion

        #region Properties
        public ProgramConfig Config
        {
            get => config;
            set
            {
                config = value;
                Notify();
            }
        }

        public Dictionary<string, string> Language
        {
            get => language;
            set
            {
                language = value;
                Notify();
            }
        }

        public SamovarDTO SelectedSamovar
        {
            get => selectedSamovar;
            set
            {
                selectedSamovar = value;
                Notify();
            }
        }

        public ObservableCollection<SamovarDTO> Samovars
        {
            get => samovars;
            set
            {
                samovars = value;
                Notify();
            }
        }        
        #endregion

        public MainViewModel()
        {
            service = new SamovarService();
            
            programConfigJSON = new ProgramConfigJSON();            
            Config = new ProgramConfig();            

            Samovars = new ObservableCollection<SamovarDTO>(service.GetAll());
            foreach (var item in Samovars)
            {
                if (!item.ImagePath.Contains(Environment.CurrentDirectory))
                {
                    item.ImagePath = $"{Environment.CurrentDirectory}/{item.ImagePath}";
                }
            }

            Config = programConfigJSON.Load("programConfig.json");
            Language = LanguageManager.GetDictionaryEnglish();            

            SortCommand = new RelayCommand(SortHandler);
            AddCommand = new RelayCommand(AddMethod);
            EditCommand = new RelayCommand(EditMethod);
            RemoveCommand = new RelayCommand(RemoveMethod);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguageMethod);
            ChangeThemeCommand = new RelayCommand(ChangeThemeMethod);
            SaveCommand = new RelayCommand(SaveMethod);
            LoadCommand = new RelayCommand(LoadMethod);
        }

        private void AddMethod(object parameter)
        {
            Samovars.Add(new SamovarDTO(Samovars.Last().Id + 1));
            SelectedSamovar = Samovars.Last();
            Singleton.getInstance().SelSam = SelectedSamovar;
            EditView editView = new EditView();
            editView.ShowDialog();

            try
            {
                if (File.Exists(SelectedSamovar.ImagePath) && (!File.Exists($"{Environment.CurrentDirectory}/Images/{Path.GetFileName(SelectedSamovar.ImagePath)}")))
                    File.Copy(SelectedSamovar.ImagePath, $"{Environment.CurrentDirectory}/Images/{Path.GetFileName(SelectedSamovar.ImagePath)}", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!File.Exists(SelectedSamovar.ImagePath))
            {
                SelectedSamovar.ImagePath = $"{Environment.CurrentDirectory}/Images/samovardefault.png";
            }

            service.CreateOrUpdate(SelectedSamovar);
        }

        private void EditMethod(object parameter)
        {
            if (SelectedSamovar != null)
            {
                Singleton.getInstance().SelSam = SelectedSamovar;
                EditView editView = new EditView();
                editView.ShowDialog();            
            
                try
                {
                    if (File.Exists(SelectedSamovar.ImagePath) && (!File.Exists($"{Environment.CurrentDirectory}/Images/{Path.GetFileName(SelectedSamovar.ImagePath)}")))
                        File.Copy(SelectedSamovar.ImagePath, $"{Environment.CurrentDirectory}/Images/{Path.GetFileName(SelectedSamovar.ImagePath)}", true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                                
                if (!File.Exists(SelectedSamovar.ImagePath))
                {
                    SelectedSamovar.ImagePath = $"{Environment.CurrentDirectory}/Images/samovardefault.png";
                }

                service.CreateOrUpdate(SelectedSamovar);
            }
        }

        private void RemoveMethod(object parameter)
        {
            service.Delete(SelectedSamovar);
            Samovars.Remove(SelectedSamovar);            
        }

        private void SortHandler(object parameter)
        {
            string sortParam = parameter.ToString();
            switch (sortParam)
            {
                case "Price (asc)":
                    Samovars = new ObservableCollection<SamovarDTO>(Samovars.OrderBy(y => y.Price));
                    break;
                case "Price (desc)":
                    Samovars = new ObservableCollection<SamovarDTO>(Samovars.OrderByDescending(y => y.Price));
                    break;
                case "Manufacturer (asc)":
                    Samovars = new ObservableCollection<SamovarDTO>(Samovars.OrderBy(y => y.ManufacturerName));
                    break;
                case "Manufacturer (desc)":
                    Samovars = new ObservableCollection<SamovarDTO>(Samovars.OrderByDescending(y => y.ManufacturerName));
                    break;
                case "Model (asc)":
                    Samovars = new ObservableCollection<SamovarDTO>(Samovars.OrderBy(y => y.Model));
                    break;
                case "Model (desc)":
                    Samovars = new ObservableCollection<SamovarDTO>(Samovars.OrderByDescending(y => y.Model));
                    break;
                case "Volume (asc)":
                    Samovars = new ObservableCollection<SamovarDTO>(Samovars.OrderBy(y => y.Volume));
                    break;
                case "Volume (desc)":
                    Samovars = new ObservableCollection<SamovarDTO>(Samovars.OrderByDescending(y => y.Volume));
                    break;
            }
        }

        private void ChangeThemeMethod(object parameter)
        {
            string theme = parameter.ToString();            
            ResourceDictionary[] dict = new ResourceDictionary[0];

            switch (theme)
            {
                case "LIGHT":
                    dict = Theme.GetLightTheme();
                    Config.Themes = "LIGHT";
                    Config.SelectedThemesIndex = 0;
                    break;

                case "DARK":
                    dict = Theme.GetDarkTheme();
                    Config.Themes = "DARK";
                    Config.SelectedThemesIndex = 1;
                    break;
            }

            App.Current.Resources.MergedDictionaries.Clear();

            foreach (var elem in dict)
            {
                App.Current.Resources.MergedDictionaries.Add(elem);
            }
        }

        private void ChangeLanguageMethod(object parameter)
        {
            string choise = parameter.ToString();

            switch (choise)
            {
                case "ENG":
                    Language = LanguageManager.GetDictionaryEnglish();
                    Config.Language = "ENG";
                    Config.SelectedLanguageIndex = 0;
                    break;

                case "RUS":
                    Language = LanguageManager.GetDictionaryRussian();
                    Config.Language = "RUS";
                    Config.SelectedLanguageIndex = 1;
                    break;
            }
        }

        private void SaveMethod(object parameter)
        {            
            programConfigJSON.Save(Config, "programConfig.json");
            service.Save(Samovars);
        }

        private void LoadMethod(object parameter)
        {
            ProgramConfig res = programConfigJSON.Load("programConfig.json");
            if (res != null)
            {
                Config = res;
                ChangeLanguageMethod(Config.Language);
                ChangeThemeMethod(Config.Themes);
            }
            else
            {
                Language = LanguageManager.GetDictionaryEnglish();
                Config = new ProgramConfig();
                Config.Language = "ENG";
                Config.Themes = "LIGHT";
            }
        }
    }
}

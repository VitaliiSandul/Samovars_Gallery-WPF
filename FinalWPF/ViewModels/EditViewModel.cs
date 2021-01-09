using FinalWPF.Infrastructure;
using Microsoft.Win32;
using MVVMFinalWPF.BLL.DTO;
using MVVMFinalWPF.BLL.Interfaces;
using MVVMFinalWPF.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalWPF.ViewModels
{
    class EditViewModel : BaseNotifyPropertyChanged
    {
        private SamovarDTO selectedSamovar;
        private IService<ManufacturerDTO> serviceManufacturer;        
        private ObservableCollection<ManufacturerDTO> manufacturers;
        private ManufacturerDTO selectedManufacturer;
        private string filePath="";

        #region Commands
        public ICommand ChooseIMGCommand { get; set; }
        #endregion

        #region Properties
        public SamovarDTO SelectedSamovar
        {
            get => selectedSamovar;
            set
            {
                selectedSamovar = value;
                Notify();
            }
        }

        public ObservableCollection<ManufacturerDTO> Manufacturers
        {
            get => manufacturers;
            set
            {
                manufacturers = value;
                Notify();
            }
        }

        public ManufacturerDTO SelectedManufacturer
        {
            get => selectedManufacturer;
            set
            {
                selectedManufacturer = value;
                SelectedSamovar.ManufacturerId = SelectedManufacturer.ManufacturerId;
                SelectedSamovar.ManufacturerName = SelectedManufacturer.ManufacturerName;
                Notify();
            }
        }

        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;

                if (filePath != "" && (!File.Exists($"{Environment.CurrentDirectory}/Images/{Path.GetFileName(filePath)}")))
                {
                    File.Copy(filePath, $"{Environment.CurrentDirectory}/Images/{Path.GetFileName(filePath)}", true);                    
                }
                SelectedSamovar.ImagePath = $"{Environment.CurrentDirectory}/Images/{Path.GetFileName(filePath)}";

                Notify();
            }
        }
        #endregion

        public EditViewModel()
        {
            SelectedSamovar = Singleton.getInstance().SelSam;
            ChooseIMGCommand = new RelayCommand(ChooseIMGMethod);

            if (SelectedSamovar.ImagePath != "")
            {
                FilePath = SelectedSamovar.ImagePath;
            }
            else
            {
                FilePath = "";
            }
            
            serviceManufacturer = new ManufacturerService();
            Manufacturers = new ObservableCollection<ManufacturerDTO>(serviceManufacturer.GetAll());
        }

        private void ChooseIMGMethod(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG|*.jpeg|JPG|*.jpg|PNG|*.png|BMP|*.bmp|GIF|*.gif|All Files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
            }
        }
    }
}

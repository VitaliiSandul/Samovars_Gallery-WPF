using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.DAL.Models
{
    public class JsonManager : IIOManager
    {
        public ObservableCollection<Samovar> Load(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<ObservableCollection<Samovar>>(json);
        }

        public void Save(ObservableCollection<Samovar> samovars, string filePath)
        {
            string json = JsonConvert.SerializeObject(samovars, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }        
    }
}

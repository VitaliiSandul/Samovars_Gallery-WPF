using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.DAL.Models
{
    public interface IIOManager
    {
        void Save(ObservableCollection<Samovar> samovars, string filePath);
        ObservableCollection<Samovar> Load(string filePath);
    }
}

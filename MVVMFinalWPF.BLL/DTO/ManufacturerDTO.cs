using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.BLL.DTO
{
    public class ManufacturerDTO : INotifyPropertyChanged
    {        
        private int manufacturerId;        
        private string manufacturerName;

        #region Constructor
        public ManufacturerDTO(int manufacturerId, string manufacturerName)
        {            
            this.manufacturerId = manufacturerId;            
            this.manufacturerName = manufacturerName;
        }

        public ManufacturerDTO(int id)
        {
            ManufacturerId = id;
        }

        public ManufacturerDTO()
        {            
            ManufacturerName = "None";
        }
        #endregion

        #region Properties
        public int ManufacturerId
        {
            get => manufacturerId;
            set
            {
                manufacturerId = value;
                Notify();
            }
        }

        public string ManufacturerName
        {
            get => manufacturerName;
            set
            {
                manufacturerName = value;
                Notify();
            }
        }       
        #endregion

        private void Notify([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

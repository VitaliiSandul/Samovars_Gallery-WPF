using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.BLL.DTO
{
    public class SamovarDTO : INotifyPropertyChanged
    {
        private int id;
        private int? manufacturerId;
        private string model;
        private int volume;
        private decimal price;
        private string imagePath;
        private string manufacturerName;

        #region Constructor
        public SamovarDTO(int id, int? manufacturerId, string model, int volume, decimal price, string imagePath, string manufacturerName)
        {
            this.id = id;
            this.manufacturerId = manufacturerId;
            this.model = model;
            this.volume = volume;
            this.price = price;
            this.imagePath = imagePath;
            this.manufacturerName = manufacturerName;
        }

        public SamovarDTO(int id)
        {
            Id = id;
            ManufacturerId = null;
            Model = "";
            Volume = 0;
            Price = 0;
            ImagePath = "";
            ManufacturerName = "";
        }

        public SamovarDTO()
        {
            ManufacturerId = null;
            Model = "None";
            Volume = 0;
            Price = 0;
            ImagePath = "";
            ManufacturerName = "None";
        }
        #endregion

        #region Properties

        public int? ManufacturerId
        {
            get => manufacturerId;
            set
            {
                manufacturerId = value;
                Notify();
            }
        }

        public string Model
        {
            get => model;
            set
            {
                model = value;
                Notify();
            }
        }

        public int Volume
        {
            get => volume;
            set
            {
                volume = value;
                Notify();
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                Notify();
            }
        }               

        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
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

        public int Id
        {
            get => id;
            set
            {
                id = value;
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

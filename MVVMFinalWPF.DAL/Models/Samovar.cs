using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.DAL.Models
{
    [Serializable]
    public class Samovar
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

        public Samovar()
        {
        }

        public Samovar(int id)
        {
            Id = id;
        }
    }
}

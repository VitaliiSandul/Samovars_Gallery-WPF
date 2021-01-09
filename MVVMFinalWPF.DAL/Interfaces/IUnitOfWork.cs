using MVVMFinalWPF.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Samovar> SamovarRepository { get; }
        IRepository<Manufacturer> ManufacturerRepository { get; }        

        void Save();
    }
}

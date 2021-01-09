using MVVMFinalWPF.DAL.Context;
using MVVMFinalWPF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShopDbContext context;
        private IRepository<Samovar> samovarRepository;
        private IRepository<Manufacturer> manufacturerRepository;               

        #region Constructor
        public UnitOfWork()
        {            
            context = new ShopDbContext();
        }
        #endregion

        #region Properties
        public IRepository<Samovar> SamovarRepository => samovarRepository = samovarRepository ?? new SamovarRepository(context);
        public IRepository<Manufacturer> ManufacturerRepository => manufacturerRepository = manufacturerRepository ?? new ManufacturerRepository(context);
        #endregion

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

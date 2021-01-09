using MVVMFinalWPF.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.DAL.Repositories
{
    public class SamovarRepository : GenericRepository<Samovar>
    {
        public SamovarRepository(DbContext context) : base(context)
        {
        }
    }
}

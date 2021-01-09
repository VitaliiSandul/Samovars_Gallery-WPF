using MVVMFinalWPF.BLL.DTO;
using MVVMFinalWPF.BLL.Interfaces;
using MVVMFinalWPF.DAL.Interfaces;
using MVVMFinalWPF.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.BLL.Services
{
    public class ManufacturerService : IService<ManufacturerDTO>
    {
        IUnitOfWork unitOfWork;

        public ManufacturerService()
        {
            unitOfWork = new UnitOfWork();
        }

        public void CreateOrUpdate(ManufacturerDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(ManufacturerDTO obj)
        {
            throw new NotImplementedException();
        }

        public ManufacturerDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            return unitOfWork.ManufacturerRepository.GetAll().Select(x => new ManufacturerDTO {
                                                                                                ManufacturerId = x.ManufacturerId,
                                                                                                ManufacturerName = x.ManufacturerName
                                                                                              }).ToList();
        }

        public void Save(IEnumerable<ManufacturerDTO> value = null)
        {
            throw new NotImplementedException();
        }
    }
}

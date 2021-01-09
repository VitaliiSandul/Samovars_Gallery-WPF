using MVVMFinalWPF.BLL.DTO;
using MVVMFinalWPF.BLL.Interfaces;
using MVVMFinalWPF.DAL.Context;
using MVVMFinalWPF.DAL.Interfaces;
using MVVMFinalWPF.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.BLL.Services
{
    public class SamovarService : IService<SamovarDTO>
    {
        IUnitOfWork unitOfWork;

        public SamovarService()
        {
            unitOfWork = new UnitOfWork();
        }

        public void CreateOrUpdate(SamovarDTO obj)
        {
            Samovar tmp = unitOfWork.SamovarRepository.GetAll().FirstOrDefault(x => x.Id == obj.Id);

            if (tmp != null)
            {
                tmp.Id = obj.Id;
                tmp.ManufacturerId = obj.ManufacturerId;
                tmp.Model = obj.Model;
                tmp.Volume = obj.Volume;
                tmp.Price = obj.Price;
                tmp.ImagePath = obj.ImagePath;
            }
            else
            {
                tmp = new Samovar
                {
                    Id = obj.Id,
                    ManufacturerId = obj.ManufacturerId,
                    Model = obj.Model,
                    Volume = obj.Volume,
                    Price = obj.Price,
                    ImagePath = obj.ImagePath
                };
            }

            unitOfWork.SamovarRepository.AddOrUpdate(tmp);
            unitOfWork.Save();
        }

        public void Delete(SamovarDTO obj)
        {
            Samovar tmp = unitOfWork.SamovarRepository.GetAll().FirstOrDefault(x => x.Id == obj.Id);

            if (tmp != null)
            {
                unitOfWork.SamovarRepository.Delete(tmp);
            }

            unitOfWork.Save();
        }

        public SamovarDTO Get(int id)
        {
            var tmp = unitOfWork.SamovarRepository.Get(id);

            return new SamovarDTO (tmp.Id,
                                    tmp.ManufacturerId,
                                    tmp.Model,
                                    tmp.Volume,
                                    tmp.Price,
                                    tmp.ImagePath,
                                    tmp.Manufacturer.ManufacturerName);
        }

        public IEnumerable<SamovarDTO> GetAll()
        {
            return unitOfWork.SamovarRepository.GetAll().Select(x => new SamovarDTO {
                                                                                        Id = x.Id,
                                                                                        ManufacturerId = x.ManufacturerId,                                                                            
                                                                                        Model = x.Model,
                                                                                        Volume = x.Volume,
                                                                                        Price = x.Price,
                                                                                        ImagePath = x.ImagePath,
                                                                                        ManufacturerName = x.Manufacturer?.ManufacturerName
                                                                                    }).ToList();
        }

        public void Save(IEnumerable<SamovarDTO> samovars = null)
        {
            foreach (var item in unitOfWork.SamovarRepository.GetAll())
            {
                item.ImagePath = $"Images/{Path.GetFileName(item.ImagePath)}";
            }
            unitOfWork.Save();
        }
    }
}

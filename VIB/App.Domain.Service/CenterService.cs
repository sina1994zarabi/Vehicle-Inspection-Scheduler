using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using App.Infra.Data.Ef.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class CenterService : ICenterService
    {

        private readonly ICenterRepository _repository;

        public CenterService(ICenterRepository centerRepository)
        {
            _repository = centerRepository;
        }

    
        public void ChangeCenterInfo(int id, Center center)
        {
            _repository.Update(id,center);
        }

        public Result Delete(int id)
        {
            return _repository.Delete(id);
        }


        public List<Center> GetAllCenters()
        {
            return _repository.GetAll();
        }

        public Center GetCenter(int id)
        {
            return _repository.Get(id);
        }

        public void RegisterNewCenter(Center center)
        {
            _repository.Add(center);
        }
    }
}

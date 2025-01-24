using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Service
{
    public class RejectedCarService : IRejectedCarService
    {
        private readonly IRejectedCarRepository _rejectedCarRepository;


        public RejectedCarService(IRejectedCarRepository rejectedCarRepository)
        {
            _rejectedCarRepository = rejectedCarRepository;
        }

        public void AddRejectedCar(RejectedCar rejectedCar)
        {
            _rejectedCarRepository.ADD(rejectedCar);
        }

        public void DeleteRejectedCar(int id)
        {
            _rejectedCarRepository.Delete(id);
        }

        public List<RejectedCar> GetAllRejectedCars()
        {
            return _rejectedCarRepository.GetAll();
        }

        public RejectedCar GetRejectedCarById(int id)
        {
            return _rejectedCarRepository.Get(id);
        }

        public void UpdateRejectedCar(RejectedCar updatedCar)
        {
            _rejectedCarRepository.Update(updatedCar);
        }
    }
}

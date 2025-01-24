using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IRejectedCarService
    {
        void AddRejectedCar(RejectedCar rejectedCar);
        RejectedCar GetRejectedCarById(int id);
        List<RejectedCar> GetAllRejectedCars();
        void UpdateRejectedCar(RejectedCar updatedCar);
        void DeleteRejectedCar(int id);
    }
}

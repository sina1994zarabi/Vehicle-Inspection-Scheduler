using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IRejectedCarRepository
    {
        void ADD(RejectedCar rejectedCar);
        RejectedCar Get(int id);
        List<RejectedCar> GetAll();
        void Update(RejectedCar rejectedCar);
        void Delete(int id);
    }
}

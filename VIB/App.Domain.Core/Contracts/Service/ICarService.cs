using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface ICarService
    {
        void Register(Car car);
        Car GetVehicle(int id);
        List<Car> GetAllVehicles();
        void ChangeVehicleInfo(int id,Car car);
        Result DeleteVehicleRecord(int id);
    }
}

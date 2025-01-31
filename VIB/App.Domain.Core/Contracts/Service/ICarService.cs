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
        Task Register(Car car);
        Task<Car> GetVehicle(int id);
        Task<List<Car>> GetAllVehicles();
        Task ChangeVehicleInfo(int id,Car car);
        Task<Result> DeleteVehicleRecord(int id);
    }
}

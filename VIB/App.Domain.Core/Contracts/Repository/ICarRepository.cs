using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ICarRepository
    {
        void Add(Car car);
        Car Get(int id);
        List<Car> GetAll();
        void Update(int id,Car car);
        Result Delete(int id);
    }
}

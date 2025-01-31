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
        Task Add(Car car);
        Task<Car> Get(int id);
        Task<List<Car>> GetAll();
        Task Update(int id,Car car);
        Task<Result> Delete(int id);
    }
}

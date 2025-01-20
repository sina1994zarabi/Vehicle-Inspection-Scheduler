using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IDayRepository
    {
        void Add(Day day);
        Day Get(int id);
        List<Day> GetAll();
        void Update(int id,Day day);
        Result Delete(int id);
    }
}

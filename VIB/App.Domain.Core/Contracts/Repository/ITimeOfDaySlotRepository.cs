using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ITimeOfDaySlotRepository
    {
        void Add(TimeOfDaySlot timeOfDaySlot);
        TimeOfDaySlot Get(int id);
        List<TimeOfDaySlot> GetAll();
        void Update(int id,TimeOfDaySlot timeOfDaySlot);
        Result Delete(int id);
    }
}

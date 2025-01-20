using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface ITimeOfDaySlotService
    {
        void RegisterNewTime(TimeOfDaySlot timeOfDaySlot);
        TimeOfDaySlot GetTimeSlot(int id);
        List<TimeOfDaySlot> GetAllTimeSlots();
        void changeTimeSlot(int id, TimeOfDaySlot timeOfDaySlot);
        Result Delete(int id);
    }
}

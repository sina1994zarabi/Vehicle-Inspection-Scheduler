using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface ITimeSlotAppService
    {
        List<TimeOfDaySlot> GetTimeOfDaySlots();
        void AddNewTimeSlot(TimeOfDaySlot timeOfDaySlot);
    }
}

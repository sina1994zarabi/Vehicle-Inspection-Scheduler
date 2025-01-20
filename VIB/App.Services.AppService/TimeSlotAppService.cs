using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AppService
{
    public class TimeSlotAppService : ITimeSlotAppService
    {
        private readonly ITimeOfDaySlotService _timeOfDaySlotService;

        public TimeSlotAppService(ITimeOfDaySlotService timeOfDaySlotService)
        {
            _timeOfDaySlotService = timeOfDaySlotService;
        }

        public void AddNewTimeSlot(TimeOfDaySlot timeOfDaySlot)
        {
            _timeOfDaySlotService.RegisterNewTime(timeOfDaySlot);
        }

        public List<TimeOfDaySlot> GetTimeOfDaySlots()
        {
            var timeSlots = new List<TimeOfDaySlot>();
            var startTime = new TimeSpan(8, 0, 0);
            var endTime = new TimeSpan(18, 0, 0);
            for (var time = startTime; time <= endTime; time = time.Add(new TimeSpan(1, 0, 0)))
            {
                var slot =
                new TimeOfDaySlot
                {
                    Time = time,
                    IsBooked = false
                };
                timeSlots.Add(slot);
            }
            return timeSlots;
        }
    }
}

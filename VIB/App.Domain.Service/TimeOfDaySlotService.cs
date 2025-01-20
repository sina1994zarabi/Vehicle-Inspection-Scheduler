using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class TimeOfDaySlotService : ITimeOfDaySlotService
    {

        private readonly ITimeOfDaySlotRepository _repository;

        public TimeOfDaySlotService(ITimeOfDaySlotRepository repository)
        {
            _repository = repository;
        }

        public void changeTimeSlot(int id, TimeOfDaySlot timeOfDaySlot)
        {
            _repository.Update(id,timeOfDaySlot);
        }

        public Result Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<TimeOfDaySlot> GetAllTimeSlots()
        {
            return _repository.GetAll();
        }

        public TimeOfDaySlot GetTimeSlot(int id)
        {
            return _repository.Get(id);
        }

        public void RegisterNewTime(TimeOfDaySlot timeOfDaySlot)
        {
            _repository.Add(timeOfDaySlot);
        }
    }
}

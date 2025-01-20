using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Repositories
{
    public class TimeOfDaySlotRepository : ITimeOfDaySlotRepository
    {
        private readonly AppDbContext _context;

        public TimeOfDaySlotRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TimeOfDaySlot timeOfDaySlot)
        {
            _context.Slots.Add(timeOfDaySlot);
            _context.SaveChanges();
        }

        public Result Delete(int id)
        {
            var slotToDelete = _context.Slots.FirstOrDefault(x => x.Id == id);
            if (slotToDelete != null)
            {
                _context.Slots.Remove(slotToDelete);
                _context.SaveChanges();
                return new Result(true, "Deleted  Successfully");
            }
            else return new Result(false, "Time Slot Not Found");
        }

        public TimeOfDaySlot Get(int id)
        {
            return _context.Slots.FirstOrDefault(x => x.Id ==  id);
        }

        public List<TimeOfDaySlot> GetAll()
        {
            return _context.Slots.ToList();
        }

        public void Update(int id,TimeOfDaySlot timeOfDaySlot)
        {
            var SlotToUpdate = _context.Slots.FirstOrDefault(x => x.Id == id);
            SlotToUpdate.DayId = timeOfDaySlot.DayId;
            SlotToUpdate.IsBooked = timeOfDaySlot.IsBooked;
            SlotToUpdate.Time = timeOfDaySlot.Time;
            _context.SaveChanges();
        }
    }
}

using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Repositories
{
    public class DayRepository : IDayRepository
    {
        private readonly AppDbContext _context;

        public DayRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Day day)
        {
            _context.Days.Add(day);
            _context.SaveChanges();
        }

        public Result Delete(int id)
        {
            var dayToDelete = _context.Days.FirstOrDefault(x => x.Id == id);
            if (dayToDelete != null)
            {
                _context.Days.Remove(dayToDelete);
                _context.SaveChanges();
                return new Result(true, "Deleted Successfully");
            }
            else return new Result(false, "Day Not Found");
        }

        public Day Get(int id)
        {
            return _context.Days.FirstOrDefault(x => x.Id == id);
        }

        public List<Day> GetAll()
        {
            return _context.Days.
                Include(x => x.Centers).
                Include(x => x.Slots).
                ToList();
        }

        public void Update(int id, Day day)
        {
            var dayToEdit = _context.Days.FirstOrDefault(x => x.Id == id);
            dayToEdit.Date = day.Date;
            dayToEdit.TimeSlotsPerDay = day.TimeSlotsPerDay;
        }
    }
}

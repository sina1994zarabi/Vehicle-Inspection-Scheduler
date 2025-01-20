using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void ChangeStatusTo(int id, StatusEnum newStatus)
        {
            var appoinment = Get(id);
            appoinment.Status = newStatus;
            _context.SaveChanges();
        }

        public Result Delete(int id)
        {
            var dateToDelete = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if (dateToDelete != null)
            {
                _context.Appointments.Remove(dateToDelete);
                _context.SaveChanges();
                return new Result(true, "Deleted Successfully");
            }
            else return new Result(false, "Appointment Not Found");
        }

        public Appointment Get(int id)
        {
            return _context.Appointments.FirstOrDefault(x => x.Id == id);
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments.
                Include(x => x.Car).
                Include(x => x.Center).
                Include(x => x.TimeOfDaySlot).
                Include(x => x.TimeOfDaySlot.Day).
                ToList();
        }

        public void Update(int id, Appointment appointment)
        {
            var dateToEdit = _context.Appointments.FirstOrDefault(x => x.Id == id);
            dateToEdit.CenterId = appointment.CenterId;
            dateToEdit.CarId = appointment.CarId;
            dateToEdit.TimeOfDaySlotId = appointment.TimeOfDaySlotId;
            _context.SaveChanges();
        }
    }
}

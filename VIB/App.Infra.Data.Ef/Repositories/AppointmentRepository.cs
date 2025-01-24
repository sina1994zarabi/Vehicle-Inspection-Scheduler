using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public string Delete(int id)
        {
            var appointmentToDelete = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if (appointmentToDelete != null)
            {
                _context.Appointments.Remove(appointmentToDelete);
                _context.SaveChanges();
                return "Successfully Deleted";
            }
            else return "Not Found";
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments.
                Include(x => x.Car).
                ToList();
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.Include(x => x.Car).
                FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, Appointment appointment)
        {
            var appontmentToEdit = GetById(id);
            appontmentToEdit.Date = appointment.Date;
            appontmentToEdit.CarId = appointment.CarId;
            appontmentToEdit.CenterId = appointment.CenterId;
        }

        public string ChangeStatusTo(int id,StatusEnum newEnum)
        {
            var appointment = GetById(id);
            appointment.Status = newEnum;
            _context.SaveChanges();
            return "Status Changed Successfully";
        }
    }
}

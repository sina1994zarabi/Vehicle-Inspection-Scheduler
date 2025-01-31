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

        public async Task Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<string> Delete(int id)
        {
            var appointmentToDelete = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            if (appointmentToDelete != null)
            {
                _context.Appointments.Remove(appointmentToDelete);
                await _context.SaveChangesAsync();
                return "Successfully Deleted";
            }
            else return "Not Found";
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _context.Appointments.
                Include(x => x.Car).
                ToListAsync();
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _context.Appointments.
                FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(int id, Appointment appointment)
        {
            var appontmentToEdit = await GetById(id);
            appontmentToEdit.Date = appointment.Date;
            appontmentToEdit.CarId = appointment.CarId;
            appontmentToEdit.CenterId = appointment.CenterId;
            appontmentToEdit.Status = appointment.Status;
            await _context.SaveChangesAsync();
        }

        //public string ChangeStatusTo(int id,StatusEnum newEnum)
        //{
        //    var appointment = GetById(id);
        //    appointment.Status = newEnum;
        //    _context.SaveChanges();
        //    return "Status Changed Successfully";
        //}
    }
}

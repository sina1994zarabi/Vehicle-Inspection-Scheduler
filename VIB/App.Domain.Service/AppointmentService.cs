using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task ChangeAppointmentInfo(int id,Appointment appointment)
        {
            await _appointmentRepository.Update(id,appointment);
        }

        //public string ChangeStatusTo(int id, StatusEnum status)
        //{
        //    return _appointmentRepository.ChangeStatusTo(id,status);
        //}

        public async Task CreateAppointment(Appointment appointment)
        {
             await _appointmentRepository.Add(appointment);
        }

        public async Task<string> Delete(int id)
        {
            return await _appointmentRepository.Delete(id);
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _appointmentRepository.GetAll();
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _appointmentRepository.GetById(id);
        }
    }
}

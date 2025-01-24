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

        public void ChangeAppointmentInfo(int id,Appointment appointment)
        {
            _appointmentRepository.Update(id,appointment);
        }

        public string ChangeStatusTo(int id, StatusEnum status)
        {
            return _appointmentRepository.ChangeStatusTo(id,status);
        }

        public void CreateAppointment(Appointment appointment)
        {
            _appointmentRepository.Add(appointment);
        }

        public string Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _appointmentRepository.GetById(id);
        }
    }
}

using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IAppointmentRepository _appiontmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appiontmentRepository = appointmentRepository;
        }

        public void ChangeInfo(int id, Appointment appointment)
        {
            _appiontmentRepository.Update(id, appointment);
        }

        public void ChangeStatusTo(int id, StatusEnum newStatus)
        {
            _appiontmentRepository.ChangeStatusTo(id, newStatus);
        }

        public Result DeleteRecord(int id)
        {
            return _appiontmentRepository.Delete(id);
        }

        public List<Appointment> GetAll()
        {
            return _appiontmentRepository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _appiontmentRepository.Get(id);
        }

        public void Register(Appointment appointment)
        {
            _appiontmentRepository.Add(appointment);
        }
    }
}

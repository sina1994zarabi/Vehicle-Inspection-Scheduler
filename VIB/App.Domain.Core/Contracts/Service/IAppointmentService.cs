using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IAppointmentService
    {
        void CreateAppointment(Appointment appointment);
        List<Appointment> GetAll();
        Appointment GetById(int id);
        void ChangeAppointmentInfo(int id,Appointment appointment);
        string ChangeStatusTo(int id, StatusEnum status);
        string Delete(int id);
    }
}

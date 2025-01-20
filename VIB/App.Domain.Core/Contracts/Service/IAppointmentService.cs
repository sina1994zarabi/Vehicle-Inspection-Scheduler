using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities.Base.Entity;
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
        void Register(Appointment appointment);
        Appointment GetById(int id);
        List<Appointment> GetAll();
        void ChangeInfo(int id, Appointment appointment);
        void ChangeStatusTo(int id, StatusEnum newStatus);
        Result DeleteRecord(int id);
    }
}

using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        Appointment Get(int id);
        List<Appointment> GetAll();
        void Update(int id, Appointment appointment);
        void ChangeStatusTo(int id, StatusEnum newStatus);
        Result Delete(int id);
    }
}

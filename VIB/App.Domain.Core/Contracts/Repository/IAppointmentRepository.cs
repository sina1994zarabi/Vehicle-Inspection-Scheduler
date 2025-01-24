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
        List<Appointment> GetAll();
        Appointment GetById(int id);
        void Update(int id,Appointment appointment);
        string ChangeStatusTo(int id, StatusEnum status);
        string Delete(int id);
    }
}

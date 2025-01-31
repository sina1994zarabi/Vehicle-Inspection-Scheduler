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
        Task Add(Appointment appointment);
        Task<List<Appointment>> GetAll();
        Task<Appointment> GetById(int id);
        Task Update(int id,Appointment appointment);
        //string ChangeStatusTo(int id, StatusEnum status);
        Task<string> Delete(int id);
    }
}

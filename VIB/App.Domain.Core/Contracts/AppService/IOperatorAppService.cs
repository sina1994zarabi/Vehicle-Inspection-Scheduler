using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IOperatorAppService
    {
        Result Login(string username, string password);
        List<Appointment> ViewPendingAppointments();
        void AddDaysWithSlots(int centerId,DateTime date,List<TimeSpan> timeSlots);
        void ConfirmAppointment(int appointmentId);
    }
}

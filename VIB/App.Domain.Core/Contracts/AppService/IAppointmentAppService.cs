using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IAppointmentAppService
    {
        List<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
        string ScheduleAppointment(Appointment appointment);
        void ConfirmAppointment(int id);
        void RejectAppointment(int id, string rejectionReason);
        void ChangeAppointmentInfo(Appointment appointment);
        void DeleteAppointment(int id);
        List<Appointment> GetAppointmentsByDate(DateTime date);
        List<RejectedCar> GetRejectedCars();
    }
}

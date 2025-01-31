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
        Task<List<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<string> ScheduleAppointment(Appointment appointment);
        //void ConfirmAppointment(int id);
        //void RejectAppointment(int id, string rejectionReason);
        Task ChangeAppointmentInfo(Appointment appointment);
        Task<string> DeleteAppointment(int id);
        //List<Appointment> GetAppointmentsByDate(DateTime date);
        List<RejectedCar> GetRejectedCars();
    }
}

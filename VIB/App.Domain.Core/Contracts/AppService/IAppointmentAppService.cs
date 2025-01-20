using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Vehicle;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IAppointmentAppService
    {
        List<TimeOfDaySlot> GetAvailableSlots(int centerId, DateTime date);
        TimeOfDaySlot GetTimeById(int id);
        List<Car> GetCarsByOwner(int ownerId);
        List<Center> GetCenters();
        List<Day> GetDays();
        void ScheduleAppointment(Appointment appointment);
        List<Appointment> GetAllAppointments(int userId);
        void DeleteAppointment(int id);
        void ChangeStatusTo(int id, StatusEnum newStatus);
    }
}

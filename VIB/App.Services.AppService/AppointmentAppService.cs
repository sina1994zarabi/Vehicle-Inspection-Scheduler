using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Vehicle;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AppService
{
    public class AppointmentAppService : IAppointmentAppService
    {

        private readonly ITimeOfDaySlotService _slotService;
        private readonly IDayService _dayService;
        private readonly ICenterService _centerService;
        private readonly ICarService _carService;
        private readonly IAppointmentService _appointmentService;


        public AppointmentAppService(ITimeOfDaySlotService slotService,
            IDayService dayService,
            ICenterService centerService,
            ICarService carService,
            IAppointmentService appointmentService )
        {
            _slotService = slotService;
            _dayService = dayService;
            _centerService = centerService;
            _carService = carService;
            _appointmentService = appointmentService;
        }

        public void ChangeStatusTo(int id, StatusEnum newStatus)
        {
            _appointmentService.ChangeStatusTo(id, newStatus);
        }

        public void DeleteAppointment(int id)
        {
            _appointmentService.DeleteRecord(id);
        }

        public List<Appointment> GetAllAppointments(int userId)
		{
			return _appointmentService.GetAll()
                .Where(x => x.Car.UserId == userId).ToList();
		}

		public List<TimeOfDaySlot> GetAvailableSlots(int centerId, DateTime date)
        {
            var day = _dayService.GetAllDays().FirstOrDefault(x => x.Date == date );
            if (day == null)  return new List<TimeOfDaySlot>();
            var center = day.Centers.FirstOrDefault(c => c.Id == centerId);
            if (center == null) return new List<TimeOfDaySlot>();
            return day.Slots.Where(x => !x.IsBooked).ToList();
        }

        public List<Car> GetCarsByOwner(int ownerId)
        {
            return _carService.GetAllVehicles().Where(x => x.User.Id == ownerId).ToList();
        }

        public List<Center> GetCenters() 
        {
            return _centerService.GetAllCenters();
        }

        public List<Day> GetDays()
        {
            return _dayService.GetAllDays();
        }

		public TimeOfDaySlot GetTimeById(int id)
		{
			return _slotService.GetTimeSlot(id);
		}

		public void ScheduleAppointment(Appointment appointment)
        {
            _appointmentService.Register(appointment);
        }
    }
}

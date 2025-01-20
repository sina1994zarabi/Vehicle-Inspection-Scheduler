using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities.Inspection;
using App.EndPoints.MVC.Models;
using App.Infra.Data.Db;
using App.Services.AppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoints.MVC.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentAppService _appService;
        private readonly IVehicleAppService _vehicleAppService;
        private readonly ICenterAppService _centerAppService;

        public AppointmentController(IAppointmentAppService appService,
            IVehicleAppService vehicleAppService,ICenterAppService centerAppService)
        {
            _appService = appService;
            _vehicleAppService = vehicleAppService;
            _centerAppService = centerAppService;
        }

        [HttpGet]
        public IActionResult BookingPanel()
        { 
            var centers = _appService.GetCenters();
            var cars = _appService.GetCarsByOwner(InMemoryDb.CurrentUser.Id);
            var days = _appService.GetDays();
            var model = new BookingViewModel
            {
                Centers = centers,
                Cars = cars,
                Days = days,
                OwnerName = InMemoryDb.CurrentUser.FirstName + " " + InMemoryDb.CurrentUser.LastName
            };
            return View(model);
        }

        public IActionResult PickBookingTime(int ownerId,int carId,int centerId,DateTime date)
        {
            AppointmentInfoHolder.CarId = carId;
            AppointmentInfoHolder.CenterId = centerId;
            var AvailableTimeSlots = _appService.GetAvailableSlots(centerId,date);
            return View(AvailableTimeSlots);
        }

        [HttpPost]
        public IActionResult ScheduleAppointment(int timeSlotId) 
        {
            var timeSlot = _appService.GetTimeById(timeSlotId);
            Appointment appointment = new Appointment() 
            {
                CarId = AppointmentInfoHolder.CarId,
                CenterId = AppointmentInfoHolder.CenterId,
                TimeOfDaySlotId = timeSlotId
			};
            _appService.ScheduleAppointment(appointment);
            return RedirectToAction("BookingPanel");
        }

        public IActionResult ViewAppointments()
        {
            var userId = InMemoryDb.CurrentUser.Id;
            var appointments = _appService.GetAllAppointments(userId);
            return View(appointments);
		}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _appService.DeleteAppointment(id);
            return RedirectToAction("ViewAppointments");
        }
	}
}

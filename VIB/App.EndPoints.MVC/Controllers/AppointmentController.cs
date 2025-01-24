using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Enums;
using App.EndPoints.MVC.Models;
using App.Infra.Data.Db;
using App.Services.AppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.EndPoints.MVC.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentAppService _appointmentAppService;
        private readonly ICarService _carService;
        private readonly ICenterService _centerService;
        private readonly IVehicleAppService _vehicleAppService;

        public AppointmentController(IAppointmentAppService appointmentAppService,
            ICarService carService,ICenterService centerService, IVehicleAppService vehicleAppService)
        {
            _appointmentAppService = appointmentAppService;
            _carService = carService;
            _centerService = centerService;
            _vehicleAppService = vehicleAppService;
        }

        public IActionResult Index()
        {
            var appointments = _appointmentAppService.GetAllAppointments()
                .Where(x => x.Car.UserId == InMemoryDb.CurrentUser.Id).
                ToList();
            return View(appointments);
        }

        public IActionResult Details(int id)
        {
            var appointment = _appointmentAppService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        public IActionResult Create()
        {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                dates.Add(DateTime.Now.AddDays(i));
            }
            var TimeSlots = new List<TimeSpan>();
            for (int i = 8;i < 20;i++)
            {
                TimeSlots.Add(TimeSpan.FromHours(i));
            }
            var cars = _carService.GetAllVehicles().
                Where(x => x.UserId == InMemoryDb.CurrentUser.Id).ToList();
            var centers = _centerService.GetAllCenters();
            var model = new BookingPanelViewModel() 
            {
                AvailableDates = dates,
                Cars = cars,
                Centers = centers,
                TimeSlots = TimeSlots
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BookingPanelViewModel appointmentInfo)
        {
            var appointment = new Appointment()
            {
                CarId = appointmentInfo.CarId,
                CenterId = appointmentInfo.CenterId,
                Date = new DateTime(appointmentInfo.date.Year,
                                    appointmentInfo.date.Month,
                                    appointmentInfo.date.Day,
                                    appointmentInfo.TimeSpan.Hours,
                                    appointmentInfo.TimeSpan.Minutes,
                                    appointmentInfo.TimeSpan.Seconds),
                Status = StatusEnum.Pending
            };
        var result = _appointmentAppService.ScheduleAppointment(appointment);
        TempData["Message"] = result;
            return RedirectToAction("Create");
    }
    public IActionResult Edit(int id)
    {
            var appointment = _appointmentAppService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointmentAppService.ChangeAppointmentInfo(appointment);
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        public IActionResult Delete(int id)
        {
            var appointment = _appointmentAppService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _appointmentAppService.DeleteAppointment(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ScheduleAppointment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ScheduleAppointment(OwnerCarViewModel ownerCarViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _vehicleAppService.ValidatePlateNumber(ownerCarViewModel.PlateNumber);
                if (result == string.Empty)
                {
                    TempData["Message"] = "شماره پلاک نامعتبر است";
                    return RedirectToAction("ScheduleAppointment");
                }
                return RedirectToAction("Create");
            }
            return View();
        }

    }
}

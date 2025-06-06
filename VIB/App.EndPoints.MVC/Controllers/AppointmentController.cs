﻿using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Vehicle;
using App.Domain.Core.Enums;
using App.EndPoints.MVC.ApiServices;
using App.EndPoints.MVC.Models;
using App.Infra.Data.Db;
using App.Services.AppService;
using FrameWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private readonly AppointmentApiService _appointmentApiService;




        public AppointmentController(IAppointmentAppService appointmentAppService,
            ICarService carService, ICenterService centerService,
            IVehicleAppService vehicleAppService,
            AppointmentApiService appointmentApiService)
        {
            _appointmentAppService = appointmentAppService;
            _carService = carService;
            _centerService = centerService;
            _vehicleAppService = vehicleAppService;
            _appointmentApiService = appointmentApiService;
        }

        public IActionResult Index()
        {
            //var appointments = _appointmentAppService.GetAllAppointments()
            //    .Where(x => x.Car.UserId == InMemoryDb.CurrentUser.Id).
            //    ToList();
            //return View(appointments);
            var resultJson = _appointmentApiService.GetAppointments();
            var appointments = System.Text.Json.JsonSerializer.
                Deserialize<List<Appointment>>(resultJson);
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
            for (int i = 8; i < 20; i++)
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

        public IActionResult InspectionRequest()
        {
            var centers = _centerService.GetAllCenters().
                Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            var viewModel = new InspectionRequestViewModel()
            {
                Centers = centers
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ProcessInspectionRequest(InspectionRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var result = _vehicleAppService.ValidatePlateNumber(inspectionRequestViewModel.PlateNumber);
                //if (result == string.Empty)
                //{
                //    TempData["Message"] = "شماره پلاک نامعتبر است";
                //    return RedirectToAction("ScheduleAppointment");
                //}
                //return RedirectToAction("Create");
                var car = new Car
                {
                    UserId = 1,
                    Model = model.CarModel,
                    Make = model.CarMake,
                    Year = model.Year,
                    LicensePlate = model.PlateNumber,
                    LastInspectionDate = null //
                };
                var appointment = new Appointment
                {
                    CarId = car.Id,
                    CenterId = model.CenterId,
                    Date = model.Date.Date + model.TimeOfDay,
                    Status = StatusEnum.Pending
                };
                var result = _appointmentAppService.ScheduleAppointment(appointment);
                TempData["Messege"] = result;
                return RedirectToAction("InspectionRequest");
            }
            return RedirectToAction("InspectionRequest");
        }

    }
}

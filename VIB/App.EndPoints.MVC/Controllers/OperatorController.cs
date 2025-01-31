using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities.Vehicle;
using App.Domain.Core.Enums;
using App.EndPoints.MVC.Models;
using App.Infra.Data.Db;
using App.Services.AppService;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IAppointmentAppService _appointmentAppService;
        private readonly IOperatorAppService _operatorAppService;
        private readonly IVehicleAppService _vehicleAppService;

        public OperatorController(IAppointmentAppService appointmentAppService,
            IOperatorAppService operatorAppService,
            IVehicleAppService vehicleAppService)
        {
            _appointmentAppService = appointmentAppService;
            _operatorAppService = operatorAppService;
            _vehicleAppService = vehicleAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var result = _operatorAppService.Login(username, password);
            if (result.IsSucced)
            {
                InMemoryDb.CurrentOperator = result.LoggedInOperator;
                return RedirectToAction("OperatorPanel");
            }
            TempData["Message"] = result.Message;
            return View("Index");
        }

        public IActionResult Logout()
        {
            _operatorAppService.LogOut();
            return RedirectToAction("Index");
        }

        public IActionResult OperatorPanel()
        {
            var model = new UserPanelViewModel
            {
                Sections = new List<PanelSection>
                {
                  new PanelSection { Title = "مشاهده نوبت های در صف انتظار",
                      Description = "برای مشاهده نوبت ها کلیک کنید" ,
                      Action = "ViewPendingAppointments",
                      Controller = "Operator"},
                  new PanelSection { Title = "تعریف نوبت های جدید",
                      Description = "برای اضافه کردن تاریخ و زمان جدید کلیک کنید.",
                      Action = "#",
                      Controller = "#"}
                  }
            };
            return View(model);
        }

        //public IActionResult ViewPendingAppointments()
        //{
        //    var appointments = _appointmentAppService.GetAllAppointments().
        //        Where(x => x.Status == StatusEnum.Pending).
        //        ToList();
        //    return View(appointments);
        //}

        //[HttpPost]
        //public IActionResult ConfirmRequest(int id)
        //{
        //    _appointmentAppService.ConfirmAppointment(id);
        //    return RedirectToAction("ViewPendingAppointments");
        //}

        //[HttpPost]
        //public IActionResult RejectRequest(int id)
        //{
        //    _appointmentAppService.RejectAppointment(id,"");
        //    var rejectedAppointment = _appointmentAppService.GetAppointmentById(id);
        //    var car = rejectedAppointment.Car;
        //    var rejectedCar = new RejectedCar() {
        //        CarId = car.Id,
        //        RejectionDate = DateTime.Now,
        //    };
        //    _vehicleAppService.LogRejectedCar(rejectedCar);
        //    return RedirectToAction("ViewPendingAppointments");
        //}
    }
}

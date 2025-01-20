using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Enums;
using App.EndPoints.MVC.Models;
using App.Infra.Data.Db;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IOperatorAppService _operatorAppService;
        private readonly IAppointmentAppService _appointmentAppService;
        private readonly IDayAppService _dayAppService;
        private readonly ITimeSlotAppService _timeSlotAppService;
        private readonly ICenterAppService _centerAppService;
        private readonly string _saipaCap;
        private readonly string _IranKhodroCap;

        public OperatorController(IOperatorAppService operatorAppService,
            IAppointmentAppService appointmentAppService,
            IDayAppService dayAppService,
            ITimeSlotAppService timeSlotAppService,
            ICenterAppService centerAppService,
            string Saipa,string IranKhodro)
        {
            _operatorAppService = operatorAppService;
            _appointmentAppService = appointmentAppService;
            _dayAppService = dayAppService;
            _timeSlotAppService = timeSlotAppService;
            _centerAppService = centerAppService;
            _saipaCap = Saipa;
            _IranKhodroCap = IranKhodro;
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
            TempData["ErrorMessgage"] = result.Message;
            return RedirectToAction("Index");
        }

        public IActionResult OperatorPanel()
        {
            var model = new UserPanelViewModel
            {
                Sections = new List<PanelSection>
                {
                  new PanelSection { 
                      Title = "مشاهده نوبت ها",
                      Description = "برای تایید نوبت های رزرو شده کلیک کنید" ,
                      Link = "ViewPendingAppointments"
                  },
                  new PanelSection { 
                      Title = "افزودن نوبت جدید",
                      Description = "برای تعریف نوبت های جدید برای مراکز کلیک کنید",
                      Link = "AddDayWithSlot" }
                  }
            };
            return View(model);
        }

        public IActionResult ViewPendingAppointments()
        {
            var result = _operatorAppService.ViewPendingAppointments();
            return View(result);
        }

        [HttpPost]
        public IActionResult Confirm(int id)
        {
            _appointmentAppService.ChangeStatusTo(id,StatusEnum.Confirmed);
            return RedirectToAction("ViewPendingAppointments");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            _appointmentAppService.ChangeStatusTo(id,StatusEnum.Rejected);
            return RedirectToAction("ViewPendingAppointments");
        }

        public IActionResult AddDayWithSlot()
        {
            var centers = _appointmentAppService.GetCenters();
            var days = _dayAppService.GetAvailableNext30Days();
            var timeSlots = _timeSlotAppService.GetTimeOfDaySlots();
            var model = new AddDayWithSlotViewModel()
            {
                Centers = centers,
                Days = days,
                TimeSlots = timeSlots
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddDayWithSlots(string centerName,DateTime Date,TimeSpan timeSlot)
        {
            int dailyCap = 0;
            if (Date.DayOfWeek == DayOfWeek.Saturday ||
                Date.DayOfWeek == DayOfWeek.Monday ||
                Date.DayOfWeek == DayOfWeek.Wednesday)
                dailyCap = int.Parse(_IranKhodroCap);
            dailyCap = int.Parse(_saipaCap);
            var day = new Day()
            {
                Date = Date,
                TimeSlotsPerDay = dailyCap,
                
            };
            _dayAppService.AddNewDay(day);
            _centerAppService.SetNewDayForCenter(centerName, day.Id);
            var timeOfDaySlot = new TimeOfDaySlot()
            {
                Time = timeSlot,
                IsBooked = false,
                DayId = day.Id,
            };
            _timeSlotAppService.AddNewTimeSlor(timeOfDaySlot);
            return RedirectToAction("AddDayWithSlot");
        }
    }
}

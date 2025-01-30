using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Vehicle;
using App.Domain.Core.Enums;
using FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AppService
{
    public class AppointmentAppService : IAppointmentAppService
    {

        private readonly IAppointmentService _appontmentService;
        private readonly ICarService _carService;
        private readonly IRejectedCarService _rejectedCarService;
        private readonly string _saipaCap;
        private readonly string _iranKhodroCap;


        public AppointmentAppService(IAppointmentService appointmentService, ICarService carService,
            string SaipaCap, string IranKhodroCap, IRejectedCarService rejectedCarService)
        {
            _appontmentService = appointmentService;
            _carService = carService;
            _saipaCap = SaipaCap;
            _iranKhodroCap = IranKhodroCap;
            _rejectedCarService = rejectedCarService;

        }

        


        public void ChangeAppointmentInfo(Appointment appointment)
        {
            _appontmentService.ChangeAppointmentInfo(appointment.Id,appointment);
        }

        public void ConfirmAppointment(int id)
        {
            _appontmentService.ChangeStatusTo(id,StatusEnum.Confirmed);
        }

        public void DeleteAppointment(int id)
        {
            _appontmentService.Delete(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appontmentService.GetAll();
        }

        public Appointment GetAppointmentById(int id)
        {
            return  _appontmentService.GetById(id);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _appontmentService.GetAll().Where(x => x.Date.Day == date.Day).ToList();
        }

        public List<RejectedCar> GetRejectedCars()
        {
            return _rejectedCarService.GetAllRejectedCars();
        }

        public void RejectAppointment(int id, string rejectionReason)
        {
           _appontmentService.ChangeStatusTo(id,StatusEnum.Rejected);
        }

        public string ScheduleAppointment(Appointment appointment)
        {
            var car = _carService.GetVehicle(appointment.CarId);
            if (car == null) return "خودرو با مشخصات وارد شده یافت نشد.";

            var currentYear = int.Parse(DateTime.Now.ToPersianString().Split('/')[0]);
            if (currentYear - car.Year > 5)
            {
                _rejectedCarService.AddRejectedCar(new RejectedCar
                {
                    CarId = car.Id,
                    RejectionDate = DateTime.Now
                });
                
                return "عمر خودرو بیش تر از 5 سال است.";
            };

            var dayOfWeek = appointment.Date.DayOfWeek;
            int MaxRequest = 0;
            MakeEnum carMake = MakeEnum.A;
            if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Wednesday)
                MaxRequest = int.Parse(_iranKhodroCap);
            if (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Thursday || dayOfWeek == DayOfWeek.Tuesday)
            {
                MaxRequest = int.Parse(_saipaCap);
                carMake = MakeEnum.B;
            }
            
            if (car.Make != carMake)
                return "خودرو شما مجاز به اخذ نوبت در این روز نیست";

            var existingAppointments = _appontmentService
            .GetAll()
            .Where(x => x.Date.Date == appointment.Date.Date)
            .Count();

            if (existingAppointments >= MaxRequest)
                return "ظرفیت در این روز تکمیل است.";

            var lastInspection = _appontmentService
           .GetAll()
           .FirstOrDefault(x => x.CarId == car.Id && x.Date.Year == DateTime.Now.Year);
            if (lastInspection != null)
                return "امکان معایته مجدد در یک سال وجود ندارد.";

            _appontmentService.CreateAppointment(appointment);
            return "نوبت معاینه فنی با موفقیت ثبت شد";
        }
    }
}

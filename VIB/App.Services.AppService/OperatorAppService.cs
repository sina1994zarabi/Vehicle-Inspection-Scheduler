using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AppService
{
    public class OperatorAppService : IOperatorAppService
    {

        private readonly IOperatorService _operatorService;
        private readonly IAppointmentService _appointmentService;

        public OperatorAppService(IOperatorService operatorService, IAppointmentService appointmentService)
        {
            _operatorService = operatorService;
            _appointmentService = appointmentService;

        }

        public void AddDaysWithSlots(int centerId, DateTime date, List<TimeSpan> timeSlots)
        {
            throw new NotImplementedException();
        }

        public void ConfirmAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Result Login(string username, string password)
        {
            var op = _operatorService.GetOperatorByUserName(username);
            if (op != null)
            {
                if (op.Password == password)
                    return new Result(true, "Logged In Successfully",@operator:op);
                return new Result(false, "Incorrect Password");
            }
            return new Result(false, "InCorrect UserName");
        }

        public List<Appointment> ViewPendingAppointments()
        {
            return _appointmentService.GetAll().Where(x => x.Status == StatusEnum.Pending).ToList();
        }
    }
}

using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using App.Infra.Data.Db;
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

        public OperatorAppService(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        public void ConfirmAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Result Login(string username, string password)
        {
            var OpToLogIn = _operatorService.GetOperators().FirstOrDefault(x => x.UserName == username);
            if (OpToLogIn != null) return new Result(true, "LoggedInSuccessfully", @operator:OpToLogIn);
            return new Result(false, "نام کاربری یا پسورد اشتباه وارد شده است."); ;
        }

        public void LogOut()
        {
            InMemoryDb.CurrentOperator = null;
        }

        public List<Appointment> ViewPendingAppointments()
        {
            throw new NotImplementedException();
        }
    }
}

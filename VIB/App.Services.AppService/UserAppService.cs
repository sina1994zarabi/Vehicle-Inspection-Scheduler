using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AppService
{
    public class UserAppService : IUserAppService
    {

        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public Result LoginWithPhoneNumber(string phoneNumber)
        {
            var UserToLogIn = _userService.GetAllUsers().FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (UserToLogIn != null) return new Result(true,"LoggedIn Successfully", UserToLogIn);
            return new Result(false, "کاربری با شماره تلفن وارد شده یافت نشد.");
        }

        public Result LoginWithUserName(string userName,string password)
        {
            var UserToLogIn = _userService.GetAllUsers().FirstOrDefault(x => x.Username == userName);
            if (UserToLogIn != null) return new Result(true, "LoggedInSuccessfully", UserToLogIn);
            return new Result(false, "نام کاربری یا رمز عبور اشتباه است.");
        }

        public Result Register(User user)
        {
            if (user.IdentificationNumber.Length != 10 || !user.IdentificationNumber.All(char.IsDigit))
                return new Result(false, "Invalid Id Number");
            _userService.Register(user);
            return new Result(true, "Successfull registration");
        }

        
    }
}

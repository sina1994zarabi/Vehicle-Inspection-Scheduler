using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        Result Register(User user);
        Result LoginWithPhoneNumber(string phoneNumber);
        Result LoginWithUserName(string userName,string password);
        
    }
}

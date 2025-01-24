using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IUserService
    {
        void Register(User user);
        User GetUserById(int id);
        List<User> GetAllUsers();
        void ChangeUserInfo(int id, User user);
        void DeleteUserRecord(int id);
    }
}

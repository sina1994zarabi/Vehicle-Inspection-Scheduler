using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(int id);
        User GetByPhoneNumber(string phoneNumber);
        User GetByUserName(string userName, string password);
        List<User> GetAll();
        void Update(int id, User user);
        Result Delete(int id);
    }
}

using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ChangeUserInfo(int id, User user)
        {
            _userRepository.Update(id,user);
        }

        public void DeleteUserRecord(int id)
        {
            _userRepository.Delete(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetUserByPhoneNumber(string phoneNumber)
        {
            return _userRepository.GetByPhoneNumber(phoneNumber);
        }

        public User GetUserByUserName(string userName, string password)
        {
            return _userRepository.GetByUserName(userName,password);
        }

        public void Register(User user)
        {
            _userRepository.Add(user);
        }
    }
}

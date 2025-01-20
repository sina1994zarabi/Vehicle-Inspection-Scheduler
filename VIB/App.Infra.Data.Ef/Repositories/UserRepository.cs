using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }


        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Result Delete(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
                return new Result(true, "User Successfully Deleted");
            }
            return new Result(false, "User Not Found");
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            var userToReturn = _context.Users.FirstOrDefault(u => u.Id == id);
            return userToReturn;
        }

        public User GetByPhoneNumber(string phoneNumber)
        {
            return _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        }

        public User GetByUserName(string userName, string password)
        {
             return _context.Users.FirstOrDefault(x => x.Username == userName && x.Password == password);
            
        }

        public void Update(int id, User user)
        {
            var userToUpdate = _context.Users.FirstOrDefault(x => x.Id == id);
            userToUpdate.Username = user.Username;
            userToUpdate.IdentificationNumber = user.IdentificationNumber;
            userToUpdate.DateOfBirth = user.DateOfBirth;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            _context.SaveChanges();
        }
    }
}

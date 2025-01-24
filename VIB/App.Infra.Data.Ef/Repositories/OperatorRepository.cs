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
    public class OperatorRepository : IOperatorRepository
    {
        private readonly AppDbContext _context;

        public OperatorRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Operator @operator)
        {
            _context.Operators.Add(@operator);
            _context.SaveChanges();
        }

        public Result Delete(int id)
        {
            var operatorToDelete = _context.Operators.FirstOrDefault(x => x.Id == id);
            if (operatorToDelete != null)
            {
                _context.Operators.Remove(operatorToDelete);
                _context.SaveChanges();
                return new Result(true, "Successfully Deleted the record of the user");
            }
            return new Result(false, "Operator Not Found");
        }

        public List<Operator> GetAll()
        {
            return _context.Operators.ToList();
        }

        public Operator GetById(int id)
        {
            return _context.Operators.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, Operator @operator)
        {
            var operatorToUpdate = _context.Operators.FirstOrDefault(x => x.Id == id);
            operatorToUpdate.UserName = @operator.UserName;
            operatorToUpdate.Password = @operator.Password;
            _context.SaveChanges();
        }
    }
}

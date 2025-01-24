using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IOperatorRepository
    {
        void Add(Operator @operator);
        Operator GetById(int id);
        List<Operator> GetAll();
        void Update(int id,Operator @operator);
        Result Delete(int id);
    }
}

using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IOperatorService
    {
        void Register(Operator @operator);
        Operator GetOperatorById (int id);
        List<Operator> GetOperators();
        Result DeleteRecord(int id);
        void ChangeInfo(int id, Operator @operator);   
    }
}

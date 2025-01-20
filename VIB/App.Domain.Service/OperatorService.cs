using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class OperatorService : IOperatorService
    {
        private readonly IOperatorRepository _operatorRepository;

        public OperatorService(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }
        public void ChangeInfo(int id, Operator @operator)
        {
            _operatorRepository.Update(id, @operator);
        }

        public Result DeleteRecord(int id)
        {
            return _operatorRepository.Delete(id);
        }

        public Operator GetOperatorById(int id)
        {
            return _operatorRepository.GetById(id);
        }

        public Operator GetOperatorByUserName(string username)
        {
            return _operatorRepository.GetByName(username);
        }

        public List<Operator> GetOperators()
        {
            return _operatorRepository.GetAll();
        }

        public void Register(Operator @operator)
        {
            _operatorRepository.Add(@operator);
        }
    }
}

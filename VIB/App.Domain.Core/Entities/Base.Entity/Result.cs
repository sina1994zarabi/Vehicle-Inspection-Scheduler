using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Base.Entity
{
    public class Result
    {
        public bool IsSucced { get; set; }
        public string Message { get; set; }
        public User LoggedInUser { get; set; }
        public Operator LoggedInOperator { get; set; }

        public Result(bool succus, string message,User user = null,Operator @operator = null)
        {
            IsSucced = succus;
            Message = message;
            LoggedInUser = user;
            LoggedInOperator = @operator;
        }
    }
}

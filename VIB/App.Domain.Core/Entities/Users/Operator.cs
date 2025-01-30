using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Users
{
    public class Operator
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateHired { get; set; }

        public string UserName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "رمز عبور باید حداقل 8 و حداکثر 16 رقم باشد")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "رمز عبور باید حداقل داری یک کاراکتر خاص باشد ")]
        public string Password { get; set; }


    }
}

using App.Domain.Core.Entities.Vehicle;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Users
{
    public class User
    {
        #region Properties
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Required]
        [Display(Name = "نام")]
        public string FirstName { get; set; }


        [StringLength(20, MinimumLength = 3)]
        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }


        public string Username { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "رمز عبور باید حداقل 8 و حداکثر 16 رقم باشد")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "رمز عبور باید حداقل داری یک کاراکتر خاص باشد ")]
        public string Password { get; set; }


        [Display(Name = "تاریخ ثبت نام")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }



        [Display(Name = "تاریخ تولد")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        [Required]
        [RegularExpression(@"^\d{10,}$", ErrorMessage = "کد ملی نامعتبر است")]
        [Display(Name = "کد ملی")]
        public string IdentificationNumber { get; set; }


        [Required]
        [RegularExpression(@"^0\d{10}$", ErrorMessage = "شماره موبایل نا معتبر است")]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }


        public GenderEnum Gender { get; set; }
        #endregion

        #region NavigationProperties

        public List<Car> cars { get; set; }


        #endregion
    }
}

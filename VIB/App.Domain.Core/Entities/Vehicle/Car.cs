using App.Domain.Core.Entities.Users;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Vehicle
{
    public class Car
    {

        #region properties
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "مدل خودرو")]
        public string Model { get; set; }


        [Required]
        [Display(Name = "سازنده خودرو")]
        public MakeEnum Make { get; set; }

        [Required]
        [Range(1886, 9999, ErrorMessage = "Please enter a valid year.")]
        [Display(Name = "سال تولید")]
        public int Year { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "شماره پلاک")]
        public string LicensePlate { get; set; }

        [Display(Name = "تاریخ آخرین معاینه")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{2}[آ-ی]\d{3}$", ErrorMessage = "شماره پلاک خودرو نامعتبر است.")]
        public DateTime? LastInspectionDate { get; set; }


        #endregion

        #region navigation properties
        public User User { get; set; }
        #endregion

    }
}

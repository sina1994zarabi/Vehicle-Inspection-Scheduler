using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Core.Entities.Vehicle
{
    public class RejectedCar
    {
        #region properties
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        [Display(Name = "دلیل رد شدن")]
        [StringLength(500)]
        public string RejectionReason { get; set; }

        [Required]
        [Display(Name = "تاریخ رد شدن")]
        [DataType(DataType.Date)]
        public DateTime RejectionDate { get; set; }
        #endregion

        #region navigation properties
        public Car Car { get; set; }
        #endregion
    }

}

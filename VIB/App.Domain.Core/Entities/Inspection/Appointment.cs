using App.Domain.Core.Entities.Vehicle;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Inspection
{
    public class Appointment
    {
        #region Properties
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CenterId { get; set; }
        [Display(Name = "تاریخ نوبت")]
        public DateTime Date { get; set; }
        [Display(Name = "وضعیت")]
        public StatusEnum Status { get; set; }
        #endregion

        #region Navigation Properties
        public Car? Car { get; set; }
        public Center? Center { get; set; }
        #endregion
    }
}

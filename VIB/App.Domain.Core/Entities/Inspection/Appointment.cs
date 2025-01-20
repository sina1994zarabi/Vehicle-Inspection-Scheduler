using App.Domain.Core.Entities.Vehicle;
using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
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
        public int TimeOfDaySlotId { get; set; }
        public StatusEnum Status { get; set; }
        #endregion

        #region navigation properties
        public Car Car { get; set; }
        public Center Center { get; set; }
        public TimeOfDaySlot TimeOfDaySlot { get; set; }
        #endregion

        public Appointment()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Inspection
{
    public class TimeOfDaySlot
    {
        #region properties
        public int Id { get; set; }
        public int DayId { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsBooked { get; set; }
        #endregion

        #region navigation property
        public Day Day { get; set; }
        #endregion
    }
}

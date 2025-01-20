using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Inspection
{
    public class Day
    {
        #region properties
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TimeSlotsPerDay { get; set; }
        #endregion

        #region navigation properties
        public List<TimeOfDaySlot> Slots { get; set; }
        public List<Center> Centers { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Inspection
{
    public class Center
    {
        #region properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int DayId { get; set; }
        #endregion

        #region navigation properties
        List<Appointment> appoinments { get; set; }
        public Day Day { get; set; }
        #endregion
    }
}

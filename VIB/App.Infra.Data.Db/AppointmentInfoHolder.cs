using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db
{
	public static class AppointmentInfoHolder
	{
		public static int CarId { get; set; }
		public static int CenterId { get; set; }
		public static int TimeOfDaySlotId { get; set; }
        public static DateTime Date { get; set; }
        public static Car Car { get; set; }
        public static Center Center { get; set; }
        public static TimeOfDaySlot TimeOfDaySlot { get; set; }

    }
}

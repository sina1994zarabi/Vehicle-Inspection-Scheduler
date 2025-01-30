using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Vehicle
{
	public class RejectedCar
	{
        public int Id { get; set; }
		public int CarId { get; set; }
		public DateTime RejectionDate { get; set; }
    }
}

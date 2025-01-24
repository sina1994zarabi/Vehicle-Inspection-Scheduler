using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Vehicle;

namespace App.EndPoints.MVC.Models
{
    public class BookingPanelViewModel
    {
        public int CarId { get; set; }
        public int CenterId { get; set; }
        public DateTime date { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public List<DateTime> AvailableDates { get; set; }
        public List<TimeSpan> TimeSlots { get; set; }
        public List<Center> Centers { get; set; }
        public List<Car> Cars { get; set; }
    }
}

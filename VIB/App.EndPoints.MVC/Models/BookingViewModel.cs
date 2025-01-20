using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Vehicle;

namespace App.EndPoints.MVC.Models
{
    public class BookingViewModel
    {
        public int OwnerId { get; set; }
        public int CarId { get; set; }
        public int CenterId { get; set; }
        public int TimeOfDaySlotId { get; set; }
        public int DayId { get; set; }
        public string OwnerName { get; set; }
        public List<Center> Centers { get; set; }
        public List<Car> Cars { get; set; }
        public List<TimeOfDaySlot> AvailableSlots { get; set; }
        public List<Day> Days { get; set; }
    }
}

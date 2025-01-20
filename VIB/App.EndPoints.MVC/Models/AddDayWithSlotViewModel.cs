using App.Domain.Core.Entities.Inspection;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.Models
{
    public class AddDayWithSlotViewModel
    {
        public int CenterId { get; set; }
        public int DayId { get; set; }
        public int TimeSlotId { get; set; }
        public List<Day> Days { get; set; }
        public List<TimeOfDaySlot> TimeSlots { get; set; }
        public List<Center> Centers { get; set; } 
    }
}

using App.Domain.Core.Entities.Inspection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Configuration
{
    public class TimeOfDaySlotConfiguration : IEntityTypeConfiguration<TimeOfDaySlot>
    {
        public void Configure(EntityTypeBuilder<TimeOfDaySlot> builder)
        {
            builder.HasData(new List<TimeOfDaySlot>() {
                new TimeOfDaySlot { Id = 1, DayId = 1, Time = new TimeSpan(9, 0, 0), IsBooked = false },
                new TimeOfDaySlot { Id = 2, DayId = 1, Time = new TimeSpan(10, 0, 0), IsBooked = false },
                new TimeOfDaySlot { Id = 3, DayId = 2, Time = new TimeSpan(9, 0, 0), IsBooked = false },
                new TimeOfDaySlot { Id = 4, DayId = 2, Time = new TimeSpan(10, 0, 0), IsBooked = false }});
        }
    }
}

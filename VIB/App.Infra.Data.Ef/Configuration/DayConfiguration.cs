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
    public class DayConfiguration : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.HasData(new List<Day>() { new Day {Id = 1, Date = new DateTime(2025,1,17), TimeSlotsPerDay = 10 },
                                              new Day {Id = 2, Date = new DateTime(2025,2,18), TimeSlotsPerDay = 10 }});
        }
    }
}

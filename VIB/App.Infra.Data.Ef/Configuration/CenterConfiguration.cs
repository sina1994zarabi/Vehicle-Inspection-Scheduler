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
    public class CenterConfiguration : IEntityTypeConfiguration<Center>
    {
        public void Configure(EntityTypeBuilder<Center> builder)
        {
            builder.HasData(new List<Center>() {
                new Center { Id = 1, Name = "مرکز 1" , Address = "آدرس مرکز یک" , ContactNumber = "xxxxxxxxx",DayId = 1},
                new Center { Id = 2, Name = "مرکز 2" , Address = "آدرس مرکز دو" , ContactNumber = "xxxxxxxxx",DayId = 2}
            });
        }
    }
}

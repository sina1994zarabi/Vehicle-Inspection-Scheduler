using App.Domain.Core.Entities.Vehicle;
using App.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(new List<Car>() 
                { new Car()
                {
                    Id = 1,
                    Make = MakeEnum.A,
                    Model = "سمند",
                    LicensePlate = "ABC-1234",
                    UserId = 1,
                    Year = new DateTime(2021,1,1).Year                
                } });
        }
    }
}

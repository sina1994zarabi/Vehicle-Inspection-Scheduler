using App.Domain.Core.Entities.Users;
using App.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new List<User>() { 
                new User { Id = 1,
                    FirstName = "سینا",
                    LastName = "ضرابی",
                    DateRegistered = DateTime.Now,
                    Username = "sinazarabi",
                    DateOfBirth = DateTime.ParseExact("27-08-1994","dd-MM-yyyy",CultureInfo.InvariantCulture),
                    Password = "sina@1994zarabi",
                    Gender = GenderEnum.male,
                    IdentificationNumber = "3241327892",
                    PhoneNumber = "09367559646"
                                }
            }
            );
        }
    }
}

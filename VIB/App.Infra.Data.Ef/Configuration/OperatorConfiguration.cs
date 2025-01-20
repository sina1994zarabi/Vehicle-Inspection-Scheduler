using App.Domain.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Configuration
{
    public class OperatorConfiguration : IEntityTypeConfiguration<Operator>
    {
        

        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.HasData(new Operator() { Id = 1, UserName = "Admin", Password = "Admin@123"});
        }
    }
}

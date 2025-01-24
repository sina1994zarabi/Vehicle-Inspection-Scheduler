using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Users;
using App.Domain.Core.Entities.Vehicle;
using App.Infra.Data.Ef.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef
{
    public class AppDbContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<RejectedCar> RejectedCars { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OperatorConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CenterConfiguration());
        }
    }
}

using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Repositories
{
    public class RejectedCarRepository : IRejectedCarRepository
    {
        private readonly AppDbContext _context;

        public RejectedCarRepository(AppDbContext context)
        {
            _context = context;
        }

        public void ADD(RejectedCar rejectedCar)
        {
            _context.RejectedCars.Add(rejectedCar);
        }

        public void Delete(int id)
        {
            var rejectedCar = _context.RejectedCars.Find(id);
            if (rejectedCar == null) throw new Exception("Rejected car not found.");

            _context.RejectedCars.Remove(rejectedCar);
            _context.SaveChanges();
        }

        public RejectedCar Get(int id)
        {
            return _context.RejectedCars.Find(id);
        }

        public List<RejectedCar> GetAll()
        {
            return _context.RejectedCars.ToList();
        }

        public void Update(RejectedCar rejectedCar)
        {
            var existingCar = _context.RejectedCars.Find(rejectedCar.Id);
            if (existingCar == null) throw new Exception("Rejected car not found.");

            existingCar.CarId = rejectedCar.CarId;
            existingCar.RejectionReason = rejectedCar.RejectionReason;
            existingCar.RejectionDate = rejectedCar.RejectionDate;

            _context.SaveChanges(); ;
        }
    }
}

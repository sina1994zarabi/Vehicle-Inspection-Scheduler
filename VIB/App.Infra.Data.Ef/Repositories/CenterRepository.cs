using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Repositories
{
    public class CenterRepository : ICenterRepository
    {
        private readonly AppDbContext _context;

        public CenterRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Center center)
        {
            _context.Centers.Add(center);
        }

        public Result Delete(int id)
        {
            var centerToDelete = _context.Centers.FirstOrDefault(x => x.Id == id);
            if (centerToDelete != null)
            {
                _context.Remove(centerToDelete);
                _context.SaveChanges();
                return new Result(true, "Deleted Successfully");
            }
            else return new Result(false, "center Not Found");
        }

        public Center Get(int id)
        {
            return _context.Centers.FirstOrDefault(x => x.Id == id);
        }

        public List<Center> GetAll()
        {
            return _context.Centers.ToList();
        }

        public Center GetByName(string name)
        {
            return _context.Centers.FirstOrDefault(x => x.Name == name);
        }

        public void Update(int id, Center center)
        {
            var centerToEdit = _context.Centers.FirstOrDefault(x => x.Id == id);
            centerToEdit.Name = center.Name;
            centerToEdit.Address = center.Address;
            centerToEdit.ContactNumber = center.ContactNumber;
            _context.SaveChanges();
        }
    }
}

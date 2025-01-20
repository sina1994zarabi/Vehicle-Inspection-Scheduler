using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class DayService : IDayService
    {
        private readonly IDayRepository _dayRepository;

        public DayService(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }


        public void ChangeDay(int id, Day day)
        {
            _dayRepository.Update(id,day);
        }

        public Result DeleteDay(int id)
        {
            return _dayRepository.Delete(id);
        }

        public Day GetADay(int id)
        {
            return _dayRepository.Get(id);
        }

        public List<Day> GetAllDays()
        {
            return _dayRepository.GetAll();
        }

        public void RegisterNewDay(Day day)
        {
            _dayRepository.Add(day);
        }
    }
}

using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IDayService
    {
        void RegisterNewDay(Day day);
        Day GetADay(int id);
        List<Day> GetAllDays();
        void ChangeDay(int id, Day day);
        Result DeleteDay(int id);
    }
}

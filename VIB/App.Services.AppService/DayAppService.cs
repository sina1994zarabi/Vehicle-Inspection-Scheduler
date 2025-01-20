using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AppService
{
    public class DayAppService : IDayAppService
    {
        private readonly IDayService _dayService;

        public DayAppService(IDayService dayService)
        {
            _dayService = dayService;
        }

        public void AddNewDay(Day day)
        {
            _dayService.RegisterNewDay(day);
        }

        public List<Day> GetAvailableNext30Days()
        {
            var days = new List<Day>();
            var currentDate = DateTime.Now;
            while (days.Count < 30)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Thursday && currentDate.DayOfWeek != DayOfWeek.Friday)
                {
                    int DailyCap = 0;
                    if (currentDate.DayOfWeek == DayOfWeek.Saturday
                        || currentDate.DayOfWeek == DayOfWeek.Monday
                        || currentDate.DayOfWeek == DayOfWeek.Wednesday)
                        DailyCap = 10;
                    if (currentDate.DayOfWeek == DayOfWeek.Sunday
                        || currentDate.DayOfWeek == DayOfWeek.Tuesday)
                        DailyCap = 12;
                   var day = new Day
                   {
                        Date = currentDate,
                        TimeSlotsPerDay = DailyCap,
                    };
                    days.Add(day);
                }
                currentDate = currentDate.AddDays(1);
            }
            return days;
        }
    }
}

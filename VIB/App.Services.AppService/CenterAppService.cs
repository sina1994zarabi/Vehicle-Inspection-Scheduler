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
	public class CenterAppService : ICenterAppService
	{
		private readonly ICenterService _centerService;

        public CenterAppService(ICenterService centerService)
        {
			_centerService = centerService;
        }

        public Center GetCenterById(int centerID)
		{
			return _centerService.GetCenter(centerID);
		}

        public void SetNewDayForCenter(string name,int dayId)
        {
            var center = _centerService.GetCenterByName(name);
            center.DayId = dayId;
            _centerService.ChangeCenterInfo(center.Id, center);
        }
    }
}

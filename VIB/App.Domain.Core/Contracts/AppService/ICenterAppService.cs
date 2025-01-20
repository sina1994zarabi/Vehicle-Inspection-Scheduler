using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
	public interface ICenterAppService
	{
		Center GetCenterById(int centerID);
		void SetNewDayForCenter(string name,int dayId);
	}
}

using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface ICenterService
    {
        void RegisterNewCenter(Center center);
        Center GetCenter(int id);
        List<Center> GetAllCenters();
        void ChangeCenterInfo(int id,Center center);
        Result Delete(int id);
    }
}

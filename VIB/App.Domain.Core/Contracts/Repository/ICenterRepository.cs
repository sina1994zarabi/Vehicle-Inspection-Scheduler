﻿using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ICenterRepository
    {
        void Add(Center center);
        Center Get(int id);
        List<Center> GetAll();
        void Update(int id,Center center);
        Result Delete(int id);
    }
}

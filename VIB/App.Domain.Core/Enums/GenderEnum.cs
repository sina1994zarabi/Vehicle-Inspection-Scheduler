using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Enums
{
    public enum GenderEnum
    {
        [Display(Name = "مرد")]
        male = 1,
        [Display(Name = "زن")]
        female = 2
    }
}

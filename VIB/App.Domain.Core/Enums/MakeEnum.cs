using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Enums
{
    public enum MakeEnum
    {
        [Display(Name = "ایران خودرو")]
        A = 1,
        [Display(Name = "سایپا")]
        B = 2
    }
}

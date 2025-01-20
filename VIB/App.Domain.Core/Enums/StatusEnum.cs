using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Enums
{
    public enum StatusEnum
    {
        [Display(Name = "در انتظار تایید")]
        Pending = 1,
        [Display(Name = "تایید شده")]
        Confirmed = 2,
        [Display(Name = "رد شده")]
        Rejected = 3
    }
}

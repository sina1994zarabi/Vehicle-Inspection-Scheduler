using App.Domain.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.Models
{
    public class InspectionRequestViewModel
    {
        [Required(ErrorMessage = "وارد کردن کد ملی الزامی است.")]
        [RegularExpression(@"^\d{10,}$", ErrorMessage = "کد ملی باید حداقل 10 رقم باشد و فقط شامل اعداد باشد.")]
        public string IdNumber { get; set; }

        [Required(ErrorMessage = "وارد کردن این فیلد الزامی است.")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "وارد کردن این فیلد الزامی است.")]
        public MakeEnum CarMake { get; set; }

        [Required(ErrorMessage = "وارد کردن سال تولید الزامی است.")]
        [Range(1370, 1403, ErrorMessage = "سال تولید باید بین 1370 و 1403 باشد.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "پلاک خودرو الزامی است.")]
        public string PlateNumber { get; set; }

        [Required(ErrorMessage = "انتخاب تاریخ الزامی است.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "انتخاب زمان الزامی است.")]
        public TimeSpan TimeOfDay { get; set; }




        [Required(ErrorMessage = "انتخاب مرکز الزامی است.")]
        public int CenterId { get; set; }



        public List<SelectListItem> Centers { get; set; } = new List<SelectListItem>();
    }
}

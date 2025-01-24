using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.Models
{
    public class OwnerCarViewModel
    {
        [Required(ErrorMessage = "وارد کردن کد ملی الزامی است.")]
        [RegularExpression(@"^\d{10,}$", ErrorMessage = "کد ملی باید حداقل 10 رقم باشد و فقط شامل اعداد باشد.")]
        public string IdNumber { get; set; }

        [Required(ErrorMessage = "پلاک خودرو الزامی است.")]
        [RegularExpression(@"^\d{2}[آ-ی]\d{3}$", ErrorMessage = "پلاک خودرو نامعتبر است")]
        public string PlateNumber { get; set; }
    }
}

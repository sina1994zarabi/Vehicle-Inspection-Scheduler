using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities.Users;
using App.EndPoints.MVC.Models;
using App.Infra.Data.Db;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmRegisteration(User user)
        {
            _userAppService.Register(user);
            return RedirectToAction("LoginWithUsername");

        }

        public IActionResult LoginWithUsername()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginWithUsername(string username,string password)
        {
            var result = _userAppService.LoginWithUserName(username, password);
            if (result.IsSucced)
            {
                InMemoryDb.CurrentUser = result.LoggedInUser;
                return RedirectToAction("UserPanel");
            }
            return View(result);
        }
        
        public IActionResult UserPanel()
        {
            var model = new UserPanelViewModel {
                Sections = new List<PanelSection>
                { 
                  new PanelSection { Title = "افزودن خودرو",
                      Description = "برای افزودن خودرو جدید کلیک کنید" ,
                      Link = ""},
                  new PanelSection { Title = "نوبت دهی معاینه فنی",
                      Description = "برای اخد نوبت معاینه فنی کلیک کنید",
                      Link = "BookingPanel" }
                  }};
            return View(model);
        }
    }
}

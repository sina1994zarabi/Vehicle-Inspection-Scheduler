using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities.Vehicle;
using App.Infra.Data.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.MVC.Controllers
{
    public class CarController : Controller
    {
        private readonly IVehicleAppService _vehicleAppService;

        public CarController(IVehicleAppService vehicleAppService)
        {
            _vehicleAppService = vehicleAppService;
        }

        public IActionResult Index()
        {
            var model = _vehicleAppService.ListOwnerCars(InMemoryDb.CurrentUser.Id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            _vehicleAppService.AddNewCar(car);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var car = _vehicleAppService.GetCarDetails(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        public IActionResult Edit(int id)
        {
            var car = _vehicleAppService.GetCarDetails(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            _vehicleAppService.EditCarInfo(car);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var car = _vehicleAppService.GetCarDetails(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _vehicleAppService.DeleteCarRecordInfo(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

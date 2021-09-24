using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IGetCars _allCars;
        private readonly ICarsCategory _allCatigory;
        public CarsController(IGetCars iGetCars, ICarsCategory iCarsCategory)
        {
            _allCars = iGetCars;
            _allCatigory = iCarsCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с автомобилями";
            CarsListViewModel obj = new CarsListViewModel
            {
                allCars = _allCars.Cars,
                currentCategory = "Автомобили"
            };
            return View(obj);
        }

    }
}

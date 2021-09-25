using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;
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
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            var cars = GetCarsСorrespondingСategory(category);
            var currentCategory = SetCurentCategory(category);
            CarsListViewModel obj = new CarsListViewModel
            {
                allCars = cars,
                currentCategory = currentCategory
            };
            return View(obj);
        }

        private string  SetCurentCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return "Все автомобили";
            }
            if (category.Equals("electro", StringComparison.OrdinalIgnoreCase))
            {
                return "Электромобили";
            }
            if (category.Equals("fuel", StringComparison.OrdinalIgnoreCase))
            {
                return "Классические автомобили";
            }
            return "Все автомобили";
        }

        private IEnumerable<Car> GetCarsСorrespondingСategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return _allCars.Cars.OrderBy(i => i.Id);
            }
            if (category.Equals("electro", StringComparison.OrdinalIgnoreCase))
            {
                return _allCars.Cars.Where(c => c.Category.Name.Equals("Электромобили")).OrderBy(i => i.Id);
            }
            if (category.Equals("fuel", StringComparison.OrdinalIgnoreCase))
            {
                return _allCars.Cars.Where(c => c.Category.Name.Equals("Классические автомобили")).OrderBy(i => i.Id);
            }
            return _allCars.Cars.OrderBy(i => i.Id);
        }
    }
}

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
    public class HomeController:Controller
    {
        private readonly IGetCars carRepository;

        public HomeController(IGetCars carRepository, ShopCart shopCart)
        {
            this.carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
        }

        public ViewResult Index()
        {
            HomeViewModel homeCars=new HomeViewModel();
            homeCars.FavCars= carRepository.FavoritCArs;
            return View(homeCars);
        }


    }
}

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
    public class ShopCartController:Controller
    {
        private readonly IGetCars carRepository;
        private readonly ShopCart shopCart;

        public ShopCartController(IGetCars carRepository, ShopCart shopCart)
        {
            this.carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
            this.shopCart = shopCart ?? throw new ArgumentNullException(nameof(shopCart));
        }
        public ViewResult Index()
        {
            var items = shopCart.GetCartItems();
            shopCart.shopCartItems = items;
            var obj = new ShopCartViewModel() 
            { 
                ShopCart = shopCart 
            };
            return View(obj);
        }
        public RedirectToActionResult addToCart (int id)
        {
            var item = carRepository.Cars.FirstOrDefault(i => i.Id == id);
            if (item!=null)
            {
                shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}

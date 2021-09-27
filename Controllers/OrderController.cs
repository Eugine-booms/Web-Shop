using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Controllers
{
    public class OrderController:Controller
    {
        public readonly IOrder orders;
        public readonly ShopCart shopCart;

        public OrderController(IOrder orders, ShopCart shopCart)
        {
            this.orders = orders ?? throw new ArgumentNullException(nameof(orders));
            this.shopCart = shopCart ?? throw new ArgumentNullException(nameof(shopCart));
        }

        public IActionResult CheckOut()
        {
            var order = new Order();
            return View(order);
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.shopCartItems = shopCart.GetCartItems();
            if (shopCart.shopCartItems.Count==0)
            {
                ModelState.AddModelError("", "Добавьте товары в корзину");
            }
            if (ModelState.IsValid)
            {
                orders.CreateOrders(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete ()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}

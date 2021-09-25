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
    }
}

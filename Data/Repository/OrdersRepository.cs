using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repository
{
    public class OrdersRepository : IOrder
    {
        private readonly ShopDbContext shopDb;
        private readonly ShopCart shopCart;

        public OrdersRepository(ShopDbContext shopDb, ShopCart shopCart )
        {
            this.shopDb = shopDb ?? throw new ArgumentNullException(nameof(shopDb));
            this.shopCart = shopCart ?? throw new ArgumentNullException(nameof(shopDb));
        }

        public void CreateOrders(Order order)
        {
            order.OrderTime = DateTime.Now;
            shopDb.Orders.Add(order);

            var items = shopCart.shopCartItems;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = item.Car.Id,
                    OrderId = order.Id,
                    Price = item.Car.Price,
                };
                shopDb.OrderDetails.Add(orderDetail);
            }
            shopDb.SaveChanges();
        }
    }
}

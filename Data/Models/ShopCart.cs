using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Data.Models
{
    public class ShopCart
    {
        private ShopDbContext appDbContext;
        public string ShopCartId { get; set; }
        public virtual ICollection<ShopCartItem> shopCartItems { get; set; }

        public ShopCart(ShopDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public static ShopCart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ShopDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car)
        {
            appDbContext.ShopCarItems.Add(new ShopCartItem() 
            { 
                ShopCartId = ShopCartId, 
                Car = car, 
                Price = car.Price 
            });
            appDbContext.SaveChanges();
        }
        public List<ShopCartItem> GetCartItems ()
        {
            return appDbContext.ShopCarItems.Where(c => c.ShopCartId == ShopCartId).Include(c => c.Car).ToList();
        }
    }
}

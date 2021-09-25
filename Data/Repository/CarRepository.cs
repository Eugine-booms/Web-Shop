using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repository
{
    public class CarRepository : IGetCars
    {
        private readonly ShopDbContext appDbContext;

        public CarRepository(ShopDbContext addDbContext)
        {
            this.appDbContext = addDbContext ?? throw new ArgumentNullException(nameof(addDbContext));
        }

        public IEnumerable<Car> Cars 
        { 
            get => appDbContext.Cars.Include(c => c.Category);
             set => appDbContext.Cars.AddRange(value);
        }
        public IEnumerable<Car> FavoritCArs 
        {
            get => appDbContext.Cars.Where(c => c.IsFavorite == true).Include(c=>c.Category);
             set => appDbContext.Cars.AddRange(value.Where(c => c.IsFavorite == true));
        }

        public Car GetCar(int carId) => appDbContext.Cars.Find(carId);
       
    }
}

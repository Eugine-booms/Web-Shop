﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
  public  interface IGetCars
    {
        IEnumerable<Car> Cars { get; set; }
        IEnumerable<Car> FavoritCArs { get; set; }
        Car GetCar(int carId);
    }
}

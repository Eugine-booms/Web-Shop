using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Mocks
{
    public class MockCars : IGetCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get => new List<Car>
                {
                    new Car
                    {
                               Name="Tesla Model S",
                               ShortDescription="Быстрый автомобиль",
                               LongDescription="Красивый быстрый и тихий автомобиль компании тесла",
                               Img="/img/tesla.jpg",
                               Price =45000,
                               IsFavorite= true,
                               Available= true,
                               Category=_carsCategory.GetCategories.First()
                    },
                    new Car
                    {
                              Name="Lada Largus",
                                    ShortDescription="Отечественная  ",
                                    LongDescription="Ну едет и едет",
                                    Img="/img/lada.jpg",
                                    Price =7000, IsFavorite= true,
                                    Available= true,
                                    Category=_carsCategory.GetCategories.Last()
                                }
                };
            set => throw new ArgumentException("Не реализована в MOCKS", "set");

        }

        public IEnumerable<Car> FavoritCArs
        {
            get => Cars.Where(c => c.IsFavorite == true);
            set => throw new ArgumentException("Не реализована в MOCKS", "set");
        }
        public Car GetCar(int carId)
        {
            throw new NotImplementedException("Не реализована в MOCKS");
        }
    }
}

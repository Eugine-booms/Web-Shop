using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Models;

namespace WebShop.Data
{
    static public class DbObjects
    {
        private static Dictionary<string, Category> category;

        public static void Initial(ShopDbContext context)
        {
           
            
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));

            }
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(CarsInit());
            }
            context.SaveChanges();
        }
        private static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category(){ CategoryName="Электромобили", Description ="Современный вид транспорта"},
                        new Category(){CategoryName="Классические автомобили", Description="Машины с ДВС"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.CategoryName, el);
                    }
                }
                return category;
            }
        }
        private static IEnumerable<Car> CarsInit()
        {
            return new List<Car>
            {
                        new Car
                        {
                               Name="Tesla Model S",
                               ShortDescription="Быстрый автомобиль",
                               LongDescription="Красивый быстрый и тихий автомобиль компании тесла",
                               Img="/img/tesla.jpg",
                               Price =4545000,
                               IsFavorite= true,
                               Available= true,
                               Category=category["Электромобили"]
                        },
                        new Car
                        {
                               Name="Nissan Leaf",
                               ShortDescription="Тихий и экономичный",
                               LongDescription="Тихий современный автомобиль компании Ниссан авто",
                               Img="/img/nissan-leaf.jpg",
                               Price = 2450000,
                               IsFavorite= true,
                               Available= true,
                               Category=category["Электромобили"]
                        },
                        new Car
                        {
                              Name="Kia x",
                               ShortDescription="Стильный современный",
                               LongDescription="Надежный корейский автомобиль",
                               Img="/img/K5-half.png",
                               Price =1370000, IsFavorite= true,
                               Available= true,
                               Category=category["Классические автомобили"]
                        },
                        new Car
                        {
                               Name="Lada Largus",
                               ShortDescription="Отечественная  ",
                               LongDescription="Ну едет и едет",
                               Img="/img/lada.jpg",
                               Price =700000, IsFavorite= true,
                               Available= true,
                               Category=category["Классические автомобили"]
                        }
            };
        }
    }
}

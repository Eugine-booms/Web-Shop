﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> GetCategories
        {
            get
            {
                return new List<Category>()
                {
                    new Category(){ Name="Электромобили", Description ="Современный вид транспорта"},
                    new Category(){Name="Класические автомобили", Description="Машины с ДВС"}
                };
            }
        }
    }
}

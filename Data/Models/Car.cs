using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Img { get; set; }
        public uint Price { get; set; }
        /// <summary>
        /// флаг отображения для лучших товаров на главной странице
        /// </summary>
        public bool IsFavorite { get; set; } 
        /// <summary>
        /// Есть ли на складе
        /// </summary>
        public bool Available { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

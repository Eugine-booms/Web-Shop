using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public DateTime OrderTime { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

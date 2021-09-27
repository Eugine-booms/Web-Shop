using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength (50)]
        [Required(ErrorMessage ="Длина имени не менее 5 символов")]
        public string Name { get; set; }
        [Display(Name = "Введите фамилию")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string Surname { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина адреса не менее 10 символов")]
        public string Adress { get; set; }
        [Display(Name = "Телефон")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "* Part numbers must be between 3 and 50 character in length.")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина адреса не менее 9 символов")]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина адреса не менее 5 символов")]
        public string EMail { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

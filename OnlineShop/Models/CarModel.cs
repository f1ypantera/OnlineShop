using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        [Display(Name = "Модель")]
        public string NameModel { get; set; }
        [Display(Name = "Производитель")]
        public string NameManufacturer { get; set; }
        [Display(Name = "Категория")]
        public string NameCategory { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
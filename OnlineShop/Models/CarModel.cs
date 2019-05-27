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
        [Required(ErrorMessage ="Введите модель")]
        public string NameModel { get; set; }
        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "Введите производителя")]
        public string NameManufacturer { get; set; }
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Введите категорию")]
        public string NameCategory { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }
        [Display(Name = "Цена $$$")]
        [Required(ErrorMessage = "Введите цену")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }
    }
}
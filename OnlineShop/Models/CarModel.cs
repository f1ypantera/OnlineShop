using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Models
{
    public class CarModel
    {
        [Key]
        [Display(Name = "ID")]
        [HiddenInput(DisplayValue = false)]
        public int CarModelId { get; set; }
        [Display(Name = "Model")]
        [Required(ErrorMessage ="Введите модель")]
        public string NameModel { get; set; }
        [Display(Name = "Manufacturer")]
        [Required(ErrorMessage = "Введите производителя")]
        public string NameManufacturer { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Введите категорию")]
        public string NameCategory { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }
        [Display(Name = "Price $$$")]
        [Required(ErrorMessage = "Введите цену")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
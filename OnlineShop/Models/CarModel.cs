using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        public string NameModel { get; set; }
        public string NameManufacturer { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
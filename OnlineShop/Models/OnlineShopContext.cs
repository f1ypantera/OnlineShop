using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineShop.Models
{
    public class OnlineShopContext :DbContext
    {
        public OnlineShopContext(): base("DefaultConnection") { }
        public DbSet<CarModel> CarModels { get; set; }
    }
}
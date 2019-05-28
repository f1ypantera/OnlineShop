using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineShop.Models
{
    public class OnlineShopContext : DbContext
    {
        public OnlineShopContext() : base("OnlineShop") { }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
   
}
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
    public class UserDbIniziallizer : CreateDatabaseIfNotExists<OnlineShopContext>
    {
        protected override void Seed(OnlineShopContext db)
        {

            db.Roles.Add(new Role { RoleID = 1, RoleName = "Admin" });
            db.Roles.Add(new Role { RoleID = 2, RoleName = "Users" });

            db.UserAccounts.Add(new UserAccount
            {
                AccountId = 1,
                UserName = "Admin",
                Email = "Admin@gmail.com",
                Password = "123456",
                PasswordConfirm = "123456",
                Name = "Admin",
                Surname = "Admin",
                Year = 1994,
                RoleID = 1

            });


            base.Seed(db);
        }
    }
}
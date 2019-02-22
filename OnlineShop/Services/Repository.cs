using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineShop.Interface;
using OnlineShop.Models;

namespace OnlineShop.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OnlineShopContext onlineShopContext;
        private readonly DbSet<T> dbSet;

        public Repository(OnlineShopContext onlineShopContext)
        {
            dbSet = onlineShopContext.Set<T>();
            this.onlineShopContext = onlineShopContext;
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
        public IEnumerable<CarModel> CarModels
        {
            get { return onlineShopContext.CarModels; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineShop.Models;

namespace OnlineShop.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Save(CarModel carModel);
      
    }
}
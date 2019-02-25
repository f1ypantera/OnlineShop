using OnlineShop.Interface;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IRepository<CarModel> carRepository;


        public NavigationController(IRepository<CarModel> carRepository)
        {
            this.carRepository = carRepository;

        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = carRepository.GetAll()
                .Select(m => m.NameCategory)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }


      
     
       
    }
}
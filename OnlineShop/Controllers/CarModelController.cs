using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Services;
using OnlineShop.Models;
using OnlineShop.Controllers;
using OnlineShop.Infrastructure;
using OnlineShop.Interface;
using Ninject;
using PagedList.Mvc;
using PagedList;

namespace OnlineShop.Controllers
{
    public class CarModelController : Controller
    {

        private readonly IRepository<CarModel> carRepository;

        public CarModelController(IRepository<CarModel> carRepository)
        {
            this.carRepository = carRepository;
        }

        public ViewResult List(string category, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            CarListViewModel carListViewModel = new CarListViewModel
            {
                CarModels = carRepository.GetAll()
                .Where(p => category == null || p.NameCategory == category)
                .OrderBy(p => p.NameModel)
                .ToPagedList(pageNumber, pageSize),
                CurrentCategory = category
            };
      
            return View(carListViewModel);
        }
       
    }
}
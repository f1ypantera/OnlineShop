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

        public ViewResult List(string category, int page = 1)
        {
            int pageSize = 3;
           
            CarListViewModel carListViewModel = new CarListViewModel
            {
                CarModels = carRepository.GetAll()            
                .OrderBy(p => p.NameModel)
                .Skip((page-1)*pageSize)
                .Take(pageSize),              
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = carRepository.GetAll().Count()
                },
                CurrentCategory = category
            };
      
            return View(carListViewModel);
        }
       
    }
}
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
        public FileContentResult GetImage(int gameId)
        {
            CarModel car = carRepository.GetAll()
                .FirstOrDefault(g => g.CarModelId == gameId);

            if (car != null)
            {
                return File(car.ImageData, car.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public ViewResult List(string category, int page = 1)
        {
            int pageSize = 3;
           
            CarListViewModel carListViewModel = new CarListViewModel
            {
                CarModels = carRepository.GetAll()
                .Where(p => category == null || p.NameCategory == category)
                .OrderBy(p => p.NameModel)
                .Skip((page-1)*pageSize)
                .Take(pageSize),              
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? carRepository.GetAll().Count() : 
                    carRepository.GetAll().Where(c => c.NameCategory == category).Count()
                    
                },
                CurrentCategory = category
            };
      
            return View(carListViewModel);
        }
       
    }
}
using OnlineShop.Interface;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {

        private readonly IRepository<CarModel> carRepository;

        public CartController(IRepository<CarModel> carRepository)
        {
            this.carRepository = carRepository;
        }

        public ViewResult Cart(string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int carId, string returnUrl)
        {
            CarModel car = carRepository.GetAll().FirstOrDefault(g => g.CarModelId == carId);

            if (car != null)
            {
                GetCart().AddItem(car);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int carId, string returnUrl)
        {
            CarModel car = carRepository.GetAll().FirstOrDefault(g => g.CarModelId == carId);

            if (car != null)
            {
                GetCart().RemoveLine(car);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

    }
}
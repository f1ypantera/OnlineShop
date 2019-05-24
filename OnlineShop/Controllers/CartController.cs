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
        private readonly IOrderProcessor orderProcessor;
        public CartController(IRepository<CarModel> carRepository , IOrderProcessor orderProcessor)
        {
            this.carRepository = carRepository;
            this.orderProcessor = orderProcessor;
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
      
        public RedirectToRouteResult AddToCart(Cart cart,int gameId, string returnUrl)
        {
            CarModel game = carRepository.GetAll()
                .FirstOrDefault(g => g.CarModelId == gameId);

            if (game != null)
            {
                cart.AddItem(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart,int gameId, string returnUrl)
        {
            CarModel game = carRepository.GetAll()
                .FirstOrDefault(g => g.CarModelId == gameId);

            if (game != null)
            {
                cart.RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

     
    }

}

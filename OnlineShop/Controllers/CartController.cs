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


        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public CartController(IRepository<CarModel> carRepository)
        {
            this.carRepository = carRepository;
        }
        public RedirectToRouteResult AddToCart(int gameId, string returnUrl)
        {
            CarModel game = carRepository.GetAll()
                .FirstOrDefault(g => g.CarModelId == gameId);

            if (game != null)
            {
                GetCart().AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int gameId, string returnUrl)
        {
            CarModel game = carRepository.GetAll()
                .FirstOrDefault(g => g.CarModelId == gameId);

            if (game != null)
            {
                GetCart().RemoveLine(game);
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

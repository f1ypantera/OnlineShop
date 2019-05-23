using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShop.Models;

namespace OnlineShop.Tests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Организация - создание нескольких тестовых игр
            CarModel car1 = new CarModel { CarModelId = 1, NameModel = "Avensis" , NameCategory = "Седан" };
            CarModel car2 = new CarModel { CarModelId = 2, NameModel = "Rav4" , NameCategory =  "Внедорожник" };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(car1);
            cart.AddItem(car2);
            List<CartLine> results = cart.Lines.ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].CarModel, car1);
            Assert.AreEqual(results[1].CarModel, car2);
        }
    }
}

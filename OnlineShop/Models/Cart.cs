using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models;

namespace OnlineShop.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddItem(CarModel carModel,int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.CarModel.CarModelId == carModel.CarModelId)
                .FirstOrDefault();
            if(line == null)
            {
                lineCollection.Add(new CartLine
                {
                    CarModel = carModel
                });
            }
            else
            {
                line.quantity += quantity;
            }

        }

        public void RemoveLine(CarModel carModel)
        {
            lineCollection.RemoveAll(l => l.CarModel.CarModelId == carModel.CarModelId);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.CarModel.Price);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
       

    }

    public class CartLine
    {
        public CarModel CarModel { get; set; }
        public int quantity { get; set; }
    }
}
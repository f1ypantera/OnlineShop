﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models;

namespace OnlineShop.Models
{
    public class CarListViewModel
    {
        public IEnumerable<CarModel> CarModels { get; set; }
    }
}
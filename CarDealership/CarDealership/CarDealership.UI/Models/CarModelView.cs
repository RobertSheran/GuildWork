﻿using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class CarModelView:CarModel
    {
        public IEnumerable<SelectListItem> Makes { get; set; }
    }
}
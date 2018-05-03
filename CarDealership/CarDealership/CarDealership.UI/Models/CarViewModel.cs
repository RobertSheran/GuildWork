using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class CarViewModel
    {
        public string Photo { get; set; }
        public string CarModel { get; set; }
        public string CarMake { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int CarId { get; set; }
    }
}
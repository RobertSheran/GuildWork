using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class DetailedCarViewModel:CarViewModel
    {
        public int Vin { get; set; }
        public int MSRP { get; set; }
        public string InteriorColor { get; set; }
        public string Transmission { get; set; }
        public string CarType { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public string BodyStyle { get; set; }
        public string Discription { get; set; }
    }
}
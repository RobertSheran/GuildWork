using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class InventoryItemView
    {
        public int Year { get; set; }
        public int Count { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int StockValue { get; set; }
    }
}
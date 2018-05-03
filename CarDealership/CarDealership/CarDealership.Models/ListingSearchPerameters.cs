using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models
{
    public class ListingSearchPerameters
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public string MakeModel { get; set; }
    }
}

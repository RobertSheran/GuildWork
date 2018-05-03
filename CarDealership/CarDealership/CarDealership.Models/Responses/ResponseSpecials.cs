using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseSpecials:Response
    {
        public List<Special> Specials { get; set; }
    }
}

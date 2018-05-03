using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseCarType:Response
    {
        public CarType CarType { get; set; }
    }
}

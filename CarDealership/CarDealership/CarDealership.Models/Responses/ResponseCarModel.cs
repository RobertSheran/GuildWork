using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseCarModel:Response
    {
        public CarModel CarModel { get; set; }
    }
}

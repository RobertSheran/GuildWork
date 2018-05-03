using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseCarModels:Response
    {
        public List<CarModel> CarModels { get; set; }
    }
}

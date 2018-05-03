using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseCarTypes:Response
    {
        public List<CarType> CarTypes{ get; set; }
    }
}

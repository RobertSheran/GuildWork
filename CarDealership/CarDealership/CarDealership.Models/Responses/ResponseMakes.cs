using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseMakes:Response
    {
        public List<Make> Makes { get; set; }
    }
}

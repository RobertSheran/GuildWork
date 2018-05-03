using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseTransmission:Response
    {
        public Transmission Transmission { get; set; }
    }
}

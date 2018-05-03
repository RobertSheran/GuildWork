using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseTransmissions:Response
    {
        public List<Transmission> Transmissions { get; set; }
    }
}

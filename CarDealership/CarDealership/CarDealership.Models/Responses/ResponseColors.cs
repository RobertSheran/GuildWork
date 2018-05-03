using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseColors:Response
    {
        public List<Color> Colors { get; set; }
    }
}

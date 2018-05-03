using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseCarss:Response
    {
        public List<Cars> Carss { get; set; }
    }
}

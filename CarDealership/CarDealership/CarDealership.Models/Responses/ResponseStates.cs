using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseStates:Response
    {
        public List<State> MyProperty { get; set; }
    }
}

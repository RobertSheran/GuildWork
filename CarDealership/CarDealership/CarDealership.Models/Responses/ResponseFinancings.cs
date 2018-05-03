using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseFinancings:Response
    {
        public List<Financing> Financings { get; set; }
    }
}

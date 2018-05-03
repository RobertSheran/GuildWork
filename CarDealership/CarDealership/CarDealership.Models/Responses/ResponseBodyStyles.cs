using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseBodyStyles:Response
    {
        public List<BodyStyle> BodyStyles { get; set; }
    }
}

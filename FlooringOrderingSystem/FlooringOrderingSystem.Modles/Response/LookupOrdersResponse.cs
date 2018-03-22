using System.Collections.Generic;

namespace FlooringOrderingSystem.Modles.Response
{
    public class LookupOrdersResponse:Response
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}

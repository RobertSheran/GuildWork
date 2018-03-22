using System.Collections.Generic;

namespace FlooringOrderingSystem.Modles.Response
{
    public class AddOrderResponse:Response
    {
        public Order OrderToAdd { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}

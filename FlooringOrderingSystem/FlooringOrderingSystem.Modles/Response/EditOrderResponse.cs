using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Modles.Response
{
    public class EditOrderResponse:Response
    {
        public Order OrderToEdit { get; set; }
    }
}

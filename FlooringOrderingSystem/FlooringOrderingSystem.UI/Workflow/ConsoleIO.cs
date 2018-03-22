using FlooringOrderingSystem.Modles;
using System;

namespace FlooringOrderingSystem.UI.Workflow
{
    internal class ConsoleIO
    {
        internal static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine("================================================");
            Console.WriteLine(order.OrderNumber + " | " + order.OrderDate);
            Console.WriteLine(order.CustomerName);
            Console.WriteLine(order.State);
            Console.WriteLine("Product: "+order.ProductType);
            Console.WriteLine("Materials: "+order.MaterialCost);
            Console.WriteLine("Labor: "+order.LaborCost);
            Console.WriteLine("Tax: "+order.Tax);
            Console.WriteLine("Total: "+order.Total);
            Console.WriteLine("================================================");  
        }
    }
}
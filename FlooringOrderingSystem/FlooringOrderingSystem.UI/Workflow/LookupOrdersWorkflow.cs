using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Modles.Response;
using System;

namespace FlooringOrderingSystem.UI.Workflow
{
    public class LookupOrdersWorkflow
    {
        public void Exicute()
        {
            Console.Clear();
            OrderManager orderManager = OrderManagerFactory.Create();
            Console.WriteLine("Lookup orders for a specified date");
            Console.WriteLine("===============================");
            Console.Write("Enter a date: ");
            string orderDate = Console.ReadLine();
            LookupOrdersResponse lookupOrderResponse = orderManager.LookupOder(orderDate);
            Console.Clear();
            if (lookupOrderResponse.Success)
            {
                foreach(var order in lookupOrderResponse.Orders)
                {
                    ConsoleIO.DisplayOrderDetails(order);
                }                
            }
            else
            {
                Console.WriteLine(lookupOrderResponse.Message);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}

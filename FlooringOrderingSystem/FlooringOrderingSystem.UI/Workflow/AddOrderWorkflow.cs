using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Response;
using System;

namespace FlooringOrderingSystem.UI.Workflow
{
    public class AddOrderWorkflow
    {
        public void Exicute()
        {
            Console.Clear();
            AddOrderResponse addOrderResponse = new AddOrderResponse();
            OrderManager orderManager = OrderManagerFactory.Create();
            Console.WriteLine("Add order");
            Console.WriteLine("===============================");
            addOrderResponse = SubLogic.MakeValidOrder();

            if (addOrderResponse.Success)
            {
                Console.Clear();
                bool areYouSure = SubLogic.ConfirmOrderToAdd(addOrderResponse.OrderToAdd);
                if (areYouSure == true)
                {
                    addOrderResponse = orderManager.AddOrder(addOrderResponse.OrderToAdd);
                    Console.WriteLine(addOrderResponse.Message);
                    Console.WriteLine("press any key to continue");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(addOrderResponse.Message);
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
            }
        }
    }
}

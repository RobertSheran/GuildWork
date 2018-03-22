using FlooringOrderingSystem.BLL;
using System;
using System.Linq;

namespace FlooringOrderingSystem.UI.Workflow
{
    public class RemoveOrderWorkflow
    {
        public void Exicute()
        {
            Console.Clear();
            Console.WriteLine("Enter order date:");
            OrderManager orderManager = OrderManagerFactory.Create();
            string date = orderManager.GetValidDate(Console.ReadLine());
            if (date != null)
            {
                Console.WriteLine("Enter an Order Number");
                string userInputOrderNumber = orderManager.GetValidOrderNumber(Console.ReadLine(), date);
                if (userInputOrderNumber != null)
                {
                    int orderNumber = int.MinValue;

                    while (!userInputOrderNumber.All(char.IsDigit))
                    {
                        Console.WriteLine("ERROR: Enter Order number as an int:");
                        userInputOrderNumber = Console.ReadLine();
                    }
                    while (!Int32.TryParse(userInputOrderNumber, out orderNumber))
                    {
                        Console.WriteLine("ERROR: Enter Order number as an int:");
                        userInputOrderNumber = Console.ReadLine();
                    }
                    Console.WriteLine("Are You Sure you want to deleat Order number: " + orderNumber + ", for the date: " + date + "?");
                    Console.WriteLine("Enter Y/N");
                    if (Console.ReadLine() == "Y")
                    {
                        orderManager.SaveWithoutRemovedOrder(date, orderNumber);
                        Console.WriteLine("order removed");
                        Console.WriteLine("press any Key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Okay, order was Not Removed");
                        Console.WriteLine("press any Key to continue");
                        Console.ReadKey();
                    }
                }
                
            }
            else
            {
                Console.WriteLine("File for Date Does not Exist");
                Console.Write("Press any Key to Continue");
                Console.ReadKey();
            }
        }
    }
}

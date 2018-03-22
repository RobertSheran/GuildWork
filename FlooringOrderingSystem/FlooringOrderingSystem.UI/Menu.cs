using FlooringOrderingSystem.UI.Workflow;
using System;

namespace FlooringOrderingSystem.UI
{
    internal class Menu
    {
        internal static void Start()
        {
            string userInput = "";
            while (userInput!="5")
            {
                Console.Clear();
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("Flooring Program");
                Console.WriteLine("\n1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");
                Console.WriteLine("\n************************************************************************************");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        LookupOrdersWorkflow displayOrdersWorkflow = new LookupOrdersWorkflow();
                        displayOrdersWorkflow.Exicute();
                        break;
                    case "2":
                        AddOrderWorkflow addOrderWorkflow = new AddOrderWorkflow();
                        addOrderWorkflow.Exicute();
                        break;
                    case "3":
                        EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
                        editOrderWorkflow.Exicute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();
                        removeOrderWorkflow.Exicute();
                        break;
                    case "5":
                        break;

                    default:
                        Console.WriteLine(userInput + " is not a valid entry. Enter the number paired with one of the options listed.");
                        userInput = Console.ReadLine();
                        break;
                }              
            }
        }
    }
}
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlooringOrderingSystem.UI
{
    public class SubLogic
    {
        internal static string MakeValidOrderDate()
        {
            Console.Write("enter an order date: ");
            string userInput = Console.ReadLine();
            while (!DateTime.TryParse(userInput, out DateTime dateTime) || (DateTime.Today.CompareTo(DateTime.Parse(userInput)) > 0))
            {
                Console.WriteLine("ERROR: date incorectly formatted. Date must be in the future");
                Console.WriteLine("Enter date in correct format: MM/dd/yyyy");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        internal static bool ConfirmOrderToAdd(Order newOrder)
        {
            bool yesAdd = false;
            Console.WriteLine("Are you sure you want to add this order?");
            Console.WriteLine("Date: " + newOrder.OrderDate);
            Console.WriteLine("Product Type: " + newOrder.ProductType);
            Console.WriteLine("Area: " + newOrder.Area);
            Console.WriteLine("Labor Cost: " + newOrder.LaborCost);
            Console.WriteLine("Material Cost: " + newOrder.MaterialCost);
            Console.WriteLine("Tax: " + newOrder.Tax);
            Console.WriteLine("Total: " + newOrder.Total);
            Console.WriteLine("\nEnter Y/N:");
            string userInput = Console.ReadLine();
            while (userInput != "Y" && userInput != "N")
            {
                Console.WriteLine("Must enter Y or N");
                userInput = Console.ReadLine();
            }
            switch (userInput.ToUpper())
            {
                case "Y":
                    yesAdd = true;
                    break;
                case "N":
                    break;
                default:
                    Console.WriteLine("ERROR: Input Y or N");
                    break;
            }
            return yesAdd;
        }

        internal static AddOrderResponse MakeValidOrder()
        {
            AddOrderResponse addOrderResponse = new AddOrderResponse();

            string orderdate = MakeValidOrderDate();
            Console.Write("enter customer name: ");
            string customername = Console.ReadLine();
            Console.WriteLine("Enter your state's abreviation.");
            Console.WriteLine("Chose from: ");
            TaxManager taxManager = TaxManagerFactory.Create();
            foreach (var someTax in taxManager.GetTaxs())
            {
                Console.WriteLine(someTax.StateAbbreviation);
            };
            string state = MakeValidState();
            if (state == null)
            {
                addOrderResponse.OrderToAdd = null;
                addOrderResponse.Success = false;
                addOrderResponse.Message = "Error: State Not Supported";
                return addOrderResponse;
            }
            string productType = DisplayAndGetProducChoice();
            decimal area = GetValidArea();
            decimal costLaborPerSquareFoot = GetCostLaborPerSquareFoot(productType);
            decimal materialCost = GetCostMaterials(area, productType);
            int orderNumber = GetOrderNumber(orderdate);
            decimal taxRate = GetTaxRate(state);
            decimal tax = (materialCost + (costLaborPerSquareFoot * area)) * (taxRate / 100);
            decimal laborCost = costLaborPerSquareFoot * area;
            decimal total = tax + materialCost + laborCost;
            decimal costPerSquareFoot = materialCost / area;

            Order order = new Order
            {
                OrderDate = orderdate,
                CustomerName = customername,
                State = state,
                ProductType = productType,
                Area = area,
                LaborCostPerSquareFoot = costLaborPerSquareFoot,
                LaborCost = laborCost,
                MaterialCost = materialCost,
                CostPerSquareFoot = costPerSquareFoot,
                OrderNumber = orderNumber,
                TaxRate = taxRate,
                Total = total,
                Tax = tax
            };

            addOrderResponse.OrderToAdd = order;
            addOrderResponse.Success = true;
            addOrderResponse.Message = "Success";

            return addOrderResponse;
        }

        public static decimal GetTaxRate(string state)
        {
            decimal taxRate = 0;
            TaxManager taxManager = TaxManagerFactory.Create();
            foreach (var tax in taxManager.LookupTax(state))
            {
                if (state == tax.StateAbbreviation)
                {
                    taxRate = tax.TaxRate;
                }
            }
            return taxRate;
        }

        private static int GetOrderNumber(string orderDate)
        {
            int orderNumber = 0;
            OrderManager orderManager = OrderManagerFactory.Create();
            if (orderManager.LookupOder(orderDate).Orders != null)
            {
                orderNumber = orderManager.LookupOder(orderDate).Orders.Max(o => o.OrderNumber) + 1;
                //foreach (var order in orderManager.LookupOder(orderDate).Orders)
                //{
                //    orderNumber++;
                //    if (order.OrderNumber >= orderNumber)
                //    {
                //        orderNumber += (1 + order.OrderNumber - orderNumber);
                //    }
                //}
            }

            return orderNumber;
        }

        public static decimal GetCostMaterials(decimal area, string productType)
        {
            decimal materialCost = 0;

            ProductManager productRepository = ProductManagerFactory.Create();

            foreach (var product in productRepository.ListProducts())
            {
                if (product.ProductType == productType)
                {
                    materialCost = product.CostPerSquareFoot;
                }
            }
            return materialCost * area;
        }

        public static decimal GetCostLaborPerSquareFoot(string productType)
        {
            ProductManager productRepository = ProductManagerFactory.Create();
            decimal costLabor = 0;
            foreach (var product in productRepository.ListProducts())
            {
                if (product.ProductType == productType)
                {
                    costLabor = product.LaborCostPerSquareFoot;
                }
            }
            return costLabor;
        }

        private static decimal GetValidArea()
        {
            Console.WriteLine("Please enter the number of Square Feet will you Buy:");
            string areaAsString = Console.ReadLine();
            decimal areaAsDecimal;

            while (!decimal.TryParse(areaAsString, out areaAsDecimal) || areaAsDecimal < 100)
            {
                Console.WriteLine("ERROR: Must be a decimal value >= 100, try again");
                areaAsString = Console.ReadLine();
            }

            return areaAsDecimal;
        }

        private static string DisplayAndGetProducChoice()
        {
            string productChoice = "";
            ProductManager productManager = ProductManagerFactory.Create();
            foreach (var product in productManager.ListProducts())
            {
                Console.WriteLine("================================================================");
                Console.WriteLine("Product Type: " + product.ProductType);
                Console.WriteLine("Product Price Per SquareFoot: " + product.CostPerSquareFoot);
                Console.WriteLine("Labor Cost Per SquareFoot: " + product.LaborCostPerSquareFoot);
                Console.WriteLine("================================================================");
            }
            Console.WriteLine("Please Enter A Product Type: ");
            productChoice = Console.ReadLine();
            List<Product> products = new List<Product>();
            while (productManager.ListProducts().All(product => product.ProductType != productChoice))
            {
                Console.WriteLine("Product Type not supported; please, refference the list above.");
                Console.WriteLine("Product choice: ");
                productChoice = Console.ReadLine();
            }
            return productChoice;

        }

        public static string MakeValidState()
        {
            TaxManager taxRepository = TaxManagerFactory.Create();
            string userInputState = Console.ReadLine().ToUpper();
            if (!taxRepository.LookupTax(userInputState).Any(state => state.StateAbbreviation == userInputState))
            {
                Console.WriteLine("State is not supported");
                Console.WriteLine("press any key to exit");
                Console.ReadKey();
                return null;
            }

            else
            {
                return userInputState;
            }
        }
    }
}
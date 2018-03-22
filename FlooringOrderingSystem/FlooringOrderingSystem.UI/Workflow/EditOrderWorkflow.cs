using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Modles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlooringOrderingSystem.UI.Workflow
{
    public class EditOrderWorkflow
    {

        public void Exicute()
        {
            Console.Clear();
            OrderManager orderManager = OrderManagerFactory.Create();

            Console.WriteLine("Enter an Order Date: ");

            string userInputDate = orderManager.GetValidDate(Console.ReadLine());
            if (userInputDate != null)
            {
                Console.WriteLine("Enter an Order Number: ");
                string userInputOrderNumber = Console.ReadLine();
                int orderNumber = int.MinValue;
                while (!userInputOrderNumber.All(char.IsDigit))
                {
                    Console.WriteLine("ERROR: Enter Order number as an int:");
                    userInputOrderNumber = Console.ReadLine();
                }
                while (!int.TryParse(userInputOrderNumber, out orderNumber))
                {
                    Console.WriteLine("order number must be entered as an int");
                    Console.WriteLine("enter order number:");
                    userInputOrderNumber = Console.ReadLine();
                }
                string inputOrderNumber = orderManager.GetValidOrderNumber(userInputOrderNumber, userInputDate);
                if (inputOrderNumber == null)
                      
                {
                    Console.WriteLine("Order Number Does not Exist for that date");
                    Console.Write("Press any Key to Continue");
                    Console.ReadKey();
                }
                else
                {
                    Order editedOrder = new Order();
                    IEnumerable<Order> orders = orderManager.LookupOder(userInputDate).Orders.Where(order => order.OrderNumber.ToString() == userInputOrderNumber);//here
                    string customerName = "";
                    string state = "";
                    string productType = "";
                    string areaAsString = "";
                    decimal area = 0;
                    foreach (var order in orders)
                    {
                        Console.WriteLine("Enter Customer Name (" + order.CustomerName + "):");
                        customerName = Console.ReadLine();
                        if (customerName == "")
                        {
                            customerName = order.CustomerName;
                        }
                        Console.WriteLine("Enter State (" + order.State + "):");
                        state = Console.ReadLine();
                        if (state == "")
                        {
                            state = order.State;
                            Console.WriteLine("Enter Product Type (" + order.ProductType + "):");
                            productType = Console.ReadLine();
                            if (productType == "")
                            {
                                productType = order.ProductType;
                            }
                            else
                            {
                                ProductManager productManager = ProductManagerFactory.Create();
                                while (productManager.ListProducts().All(product => product.ProductType != productType))
                                {
                                    Console.WriteLine("invalid product type. product types are: ");
                                    foreach (var product in productManager.ListProducts())
                                    {
                                        Console.WriteLine(product.ProductType);
                                    }
                                    Console.WriteLine("Enter Product Type:");
                                    productType = Console.ReadLine();
                                }
                            }

                            Console.WriteLine("Enter Area (" + order.Area + "):");
                            areaAsString = Console.ReadLine();
                            if (areaAsString == "")
                            {
                                area = order.Area;
                            }
                            else
                            {
                                while(!decimal.TryParse(areaAsString,out area)||area<100)
                                {
                                    Console.WriteLine("area must be a decimal > 100");
                                    areaAsString = Console.ReadLine();
                                }

                                area = decimal.Parse(areaAsString);
                            }

                            editedOrder = order;

                            editedOrder.MaterialCost = SubLogic.GetCostMaterials(area, productType);
                            editedOrder.CostPerSquareFoot = (SubLogic.GetCostMaterials(area, productType)) / area;
                            editedOrder.TaxRate = SubLogic.GetTaxRate(state);
                            editedOrder.LaborCostPerSquareFoot = SubLogic.GetCostLaborPerSquareFoot(productType);
                            editedOrder.LaborCost = SubLogic.GetCostLaborPerSquareFoot(productType) * area;
                            editedOrder.Area = area;
                            editedOrder.CustomerName = customerName;
                            editedOrder.ProductType = productType;
                            editedOrder.State = state;
                            editedOrder.Tax = (editedOrder.MaterialCost + editedOrder.LaborCost) * (editedOrder.TaxRate / 100);
                            editedOrder.Total = (editedOrder.Tax + editedOrder.MaterialCost + editedOrder.LaborCost);

                            Console.WriteLine("Are you sure you would like to Edit This Order?");
                            Console.WriteLine("Enter Y to save changes: ");
                            if (Console.ReadLine() == "Y")
                            {
                                editedOrder.OrderDate = userInputDate;
                                bool wasEdited = orderManager.SaveEditedOrder(editedOrder);
                                Console.Clear();
                                Console.WriteLine("Changes have been Saved. press any key to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Changes were not Saved. press any key to continue");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            TaxManager taxRepository = TaxManagerFactory.Create();
                            if (taxRepository.LookupTax(state).Any(tax=> tax.StateAbbreviation==state))
                            {
                                Console.WriteLine("Enter Product Type (" + order.ProductType + "):");
                                productType = Console.ReadLine();
                                if (productType == "")
                                {
                                    productType = order.ProductType;
                                }
                                Console.WriteLine("Enter Area (" + order.Area + "):");
                                areaAsString = Console.ReadLine();
                                if (areaAsString == "")
                                {
                                    area = order.Area;
                                }
                                else
                                {
                                    area = decimal.Parse(areaAsString);
                                }

                                editedOrder = order;

                                editedOrder.MaterialCost = SubLogic.GetCostMaterials(area, productType);
                                editedOrder.CostPerSquareFoot = (SubLogic.GetCostMaterials(area, productType)) / area;
                                editedOrder.TaxRate = SubLogic.GetTaxRate(state);
                                editedOrder.LaborCostPerSquareFoot = SubLogic.GetCostLaborPerSquareFoot(productType);
                                editedOrder.LaborCost = SubLogic.GetCostLaborPerSquareFoot(productType) * area;
                                editedOrder.Area = area;
                                editedOrder.CustomerName = customerName;
                                editedOrder.ProductType = productType;
                                editedOrder.State = state;
                                editedOrder.Tax = (editedOrder.MaterialCost + editedOrder.LaborCost) * (editedOrder.TaxRate / 100);
                                editedOrder.Total = (editedOrder.Tax + editedOrder.MaterialCost + editedOrder.LaborCost);

                                Console.WriteLine("Are you sure you would like to Edit This Order?");
                                Console.WriteLine("Enter Y to save changes: ");
                                if (Console.ReadLine() == "Y")
                                {
                                    orderManager.SaveEditedOrder(editedOrder);
                                    Console.Clear();
                                    Console.WriteLine("Changes have been Saved. press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Changes were not Saved. press any key to continue");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("State is not supported");
                                Console.WriteLine("press any key to exit");
                                Console.ReadKey();

                            }
                        }
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

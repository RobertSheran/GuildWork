using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Interface;
using FlooringOrderingSystem.Modles.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlooringOrderingSystem.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        public static string _filePath { get; set; }
        //public FileOrderRepository(string filePath)
        //{
        //    _filePath = filePath;
        //}
        private List<Order> _orders;
        public List<Order> LoadOrders(string orderDate)
        {
            //ChangeOrderFilePath(orderDate);
            //_filePath = Settings.filePathOrders;
            List<Order> Orders = new List<Order>();
            if (!File.Exists(ChangeOrderFilePath(orderDate)))
            {
                _orders = null;
                return null;
            }
            else
            {
                using (StreamReader streamReader = new StreamReader(ChangeOrderFilePath(orderDate)))
                {
                    string line;
                    streamReader.ReadLine();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Order order = new Order();
                        string[] columns = line.Split(',');
                        order.OrderNumber = int.Parse(columns[0]);
                        order.CustomerName = columns[1];
                        order.State = columns[2];
                        order.TaxRate = decimal.Parse(columns[3]);
                        order.ProductType = columns[4];
                        order.Area = decimal.Parse(columns[5]);
                        order.CostPerSquareFoot = decimal.Parse(columns[6]);
                        order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                        order.MaterialCost = decimal.Parse(columns[8]);
                        order.LaborCost = decimal.Parse(columns[9]);
                        order.Tax = decimal.Parse(columns[10]);
                        order.Total = decimal.Parse(columns[11]);
                        order.OrderDate = orderDate;
                        Orders.Add(order);
                    }
                    _orders = Orders;
                }
            }
            List<Order> list = new List<Order>();
            foreach (var order in _orders.Where(order => order.OrderDate == orderDate))
            {
                list.Add(order);
            }
            return _orders.ToList();
        }
        public bool SaveEditedOrder(Order newOrder)
        {
            using (StreamReader streamReader = new StreamReader(ChangeOrderFilePath(newOrder.OrderDate)))
            {
                List<Order> list = new List<Order>();
                foreach (var order in _orders)
                {
                    if (order.OrderNumber == newOrder.OrderNumber)
                    {
                        list.Add(newOrder);
                    }
                    else
                    {
                        list.Add(order);
                    }
                }
                _orders = list;
            }
            using (StreamWriter streamWriter = new StreamWriter(ChangeOrderFilePath(newOrder.OrderDate)))
            {
                streamWriter.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var anOrder in _orders)
                {
                    streamWriter.WriteLine(anOrder.OrderNumber + "," + anOrder.CustomerName + "," + anOrder.State + "," + anOrder.TaxRate + "," + anOrder.ProductType + "," + anOrder.Area + "," + anOrder.CostPerSquareFoot + "," + anOrder.LaborCostPerSquareFoot + "," + anOrder.MaterialCost + "," + anOrder.LaborCost + "," + anOrder.Tax + "," + anOrder.Total);
                }
            }
            return _orders.Any(order => order == newOrder);
        }
        public bool SaveWithoutRemovedOrder(int orderNumber, string date)
        {          
            
            //_filePath = Settings.filePathOrders;
            List<Order> Orders = new List<Order>();
            if (!File.Exists(ChangeOrderFilePath(date)))
            {
                _orders = null;
            }
            else
            {
                using (StreamReader streamReader = new StreamReader(ChangeOrderFilePath(date)))
                {
                    string line;
                    streamReader.ReadLine();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Order order = new Order();
                        string[] columns = line.Split(',');
                        order.OrderNumber = int.Parse(columns[0]);
                        order.CustomerName = columns[1];
                        order.State = columns[2];
                        order.TaxRate = decimal.Parse(columns[3]);
                        order.ProductType = columns[4];
                        order.Area = decimal.Parse(columns[5]);
                        order.CostPerSquareFoot = decimal.Parse(columns[6]);
                        order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                        order.MaterialCost = decimal.Parse(columns[8]);
                        order.LaborCost = decimal.Parse(columns[9]);
                        order.Tax = decimal.Parse(columns[10]);
                        order.Total = decimal.Parse(columns[11]);
                        order.OrderDate = date;
                        Orders.Add(order);
                    }
                    _orders = Orders;
                }
            }
            List<Order> list = new List<Order>();
            foreach (var order in _orders)
            {
                if (order.OrderDate == date && order.OrderNumber != orderNumber)
                {
                    list.Add(order);
                }
            }
            _orders = list;

            using (StreamWriter streamWriter = new StreamWriter(ChangeOrderFilePath(date)))
            {
                streamWriter.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var anOrder in _orders)
                {
                    streamWriter.WriteLine(anOrder.OrderNumber + "," + anOrder.CustomerName + "," + anOrder.State + "," + anOrder.TaxRate + "," + anOrder.ProductType + "," + anOrder.Area + "," + anOrder.CostPerSquareFoot + "," + anOrder.LaborCostPerSquareFoot + "," + anOrder.MaterialCost + "," + anOrder.LaborCost + "," + anOrder.Tax + "," + anOrder.Total);
                }
            }

            return _orders.All(order => order.OrderNumber != orderNumber);
        }
        public bool SaveNewOrder(Order order)
        {
            //ChangeOrderFilePath(order.OrderDate);
            //_filePath = Settings.filePathOrders;
            List<Order> Orders = new List<Order>();
            if (!File.Exists(ChangeOrderFilePath(order.OrderDate)))
            {
                _orders = null;
            }
            else
            {
                using (StreamReader streamReader = new StreamReader(ChangeOrderFilePath(order.OrderDate)))
                {
                    string line;
                    streamReader.ReadLine();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Order anOrder = new Order();
                        string[] columns = line.Split(',');
                        anOrder.OrderNumber = int.Parse(columns[0]);
                        anOrder.CustomerName = columns[1];
                        anOrder.State = columns[2];
                        anOrder.TaxRate = decimal.Parse(columns[3]);
                        anOrder.ProductType = columns[4];
                        anOrder.Area = decimal.Parse(columns[5]);
                        anOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                        anOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                        anOrder.MaterialCost = decimal.Parse(columns[8]);
                        anOrder.LaborCost = decimal.Parse(columns[9]);
                        anOrder.Tax = decimal.Parse(columns[10]);
                        anOrder.Total = decimal.Parse(columns[11]);
                        anOrder.OrderDate = order.OrderDate;
                        Orders.Add(anOrder);
                    }
                    _orders = Orders;
                }
            }

            if (_orders == null)
            {
                _orders = new List<Order>()
                {
                    order
                };
            }

            else
            {
                _orders.Add(order);
            }
            using (StreamWriter streamWriter = new StreamWriter(ChangeOrderFilePath(order.OrderDate)))
            {

                streamWriter.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var anOrder in _orders)
                {
                    streamWriter.WriteLine(anOrder.OrderNumber + "," + anOrder.CustomerName + "," + anOrder.State + "," + anOrder.TaxRate + "," + anOrder.ProductType + "," + anOrder.Area + "," + anOrder.CostPerSquareFoot + "," + anOrder.LaborCostPerSquareFoot + "," + anOrder.MaterialCost + "," + anOrder.LaborCost + "," + anOrder.Tax + "," + anOrder.Total);
                }
            }
            return _orders.Any(daOrder => daOrder.OrderNumber == order.OrderNumber);
        }
        public string CheckDateExists(string userInput)
        {
            ChangeOrderFilePath(userInput);
            if (!File.Exists(ChangeOrderFilePath(userInput)))
            {
                //Console.WriteLine("File for Date Does not Exist");
                //Console.Write("Press any Key to Continue");
                //Console.ReadKey();
                return null;
            }
            else return userInput;
        }
        public string CheckEditAddOrderNumber(string userInput, string orderDate)
        {
            int orderNumber = int.Parse(userInput);
            List<Order> orders = new List<Order>();

            using (StreamReader streamReader = new StreamReader(ChangeOrderFilePath(orderDate)))
            {

                string line = "";
                streamReader.ReadLine();
                while ((line = streamReader.ReadLine()) != null)
                {
                    Order order = new Order();
                    string[] columns = line.Split(',');
                    order.OrderNumber = int.Parse(columns[0]);
                    orders.Add(order);
                }
            }

            if (orders.Any(order => order.OrderNumber == orderNumber))
            {
                return userInput;
            }
            else
            {
                return null;
            }
        }

        public static string ChangeOrderFilePath(string userInput)
        {
            string dateForPath = userInput.Replace("/", "") + ".txt";
            string filePathOrders = @"C:\Users\user\Documents\Data\Orders_";
            return filePathOrders + dateForPath;
        }

    }
}

using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using FlooringOrderingSystem.Modles.Response;

namespace FlooringOrderingSystem.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        private static Order _order = new Order
        {
            OrderNumber = 0,
            CustomerName = "Test Order",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M,
            OrderDate = "01/01/2020"
        };
        private static Order _order2 = new Order
        {
            OrderNumber = 2,
            CustomerName = "Test Order2",
            State = "OH",
            TaxRate = 6.2M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 45.00M,
            Tax = 6.88M,
            Total = 101.88M,
            OrderDate = "01/01/2020"
        };
        private static Order _order3 = new Order
        {
            OrderNumber = 4,
            CustomerName = "Test Order3",
            State = "OH",
            TaxRate = 6.2M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 45.00M,
            Tax = 6.88M,
            Total = 101.88M,
            OrderDate = "01/01/2020"
        };
        private static List<Order> _orders = new List<Order>
        {
            _order,
            _order2,
            _order3
        };
        public List<Order> LoadOrders(string orderDate)
        {
            List<Order> list = new List<Order>();
            List<Order> orders = _orders;
            foreach (var order in orders.Where(order => order.OrderDate == orderDate))
            {
                list.Add(order);
            }
            return list;
        }
        public bool SaveEditedOrder(Order newOrder)
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
            return _orders.Any(order => order == newOrder);
        }
        public bool SaveNewOrder(Order order)
        {
            _orders.Add(order);
            return _orders.Any(daOrder => daOrder.OrderNumber == order.OrderNumber);

        }
        public bool SaveWithoutRemovedOrder(int orderNumber, string date)
        {
            List<Order> list = new List<Order>();
            foreach (var order in _orders)
            {
                if (order.OrderDate == date && order.OrderNumber != orderNumber)
                {
                    list.Add(order);
                }
            }
            _orders = list;

            return _orders.All(order => order.OrderNumber != orderNumber);
        }
        public string CheckDateExists(string userInput)
        {
            if (_orders.All(order => order.OrderDate != userInput))
            {
                Console.WriteLine("File for Date Does not Exist");
                Console.Write("Press any Key to Continue");
                Console.ReadKey();
                return null;
            }
            else return userInput;
        }
        public string CheckEditAddOrderNumber(string userInput, string date)
        {
            if (_orders.Any(order => order.OrderNumber == int.Parse(userInput))&&_orders.Any(o=>o.OrderDate==date))
            {
                return userInput;
            }
            else
            {
                return null;
            }
        }
    }
}

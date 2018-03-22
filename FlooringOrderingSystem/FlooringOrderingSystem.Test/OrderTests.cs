using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Response;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlooringOrderingSystem.Test
{
    //You want to write tests to make sure your file repos are doing what you want 
    //(and to do that you need to write setup code to copy over seed data into the correct folders) 
    //and you want to write tests to make sure that your managers work correctly (using the in-memory test repos).

    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void CanLookupOrderTest()
        {
            OrderManager orderManager = new OrderManager(new OrderTestRepository());
            bool success = orderManager.LookupOder("01/01/2020").Success;
            bool fail = orderManager.LookupOder("01/02/9999").Success;
            Assert.IsTrue(success);
            Assert.IsFalse(fail);
        }

        [Test]
        public void CanLoadOrdersTest()
        {
            OrderManager orderManager = new OrderManager(new OrderTestRepository());
            LookupOrdersResponse orderLookupResponse = orderManager.LookupOder("01/01/2020");
            Assert.IsTrue(orderLookupResponse.Success);
            orderLookupResponse = orderManager.LookupOder("01/02/2020");
            Assert.IsFalse(orderLookupResponse.Success);
        }



        [Test]
        public void CanAddOrderTest()
        {
            Order order = new Order
            {
                Area = 100,
                OrderDate = "20/20/2020",
                OrderNumber = 1,
                CostPerSquareFoot = 10,
                CustomerName = "JJ",
                LaborCost = 100,
                LaborCostPerSquareFoot = 100,
                MaterialCost = 4,
                ProductType = "Wood",
                State = "WA",
                Tax = 34,
                Total = 150,
                TaxRate = 5.0M
            };

            Order order2 = new Order
            {
                Area = 0,
                OrderDate = "20/20/2020",
                OrderNumber = 1,
                CostPerSquareFoot = 10,
                CustomerName = "JJ",
                LaborCost = 100,
                LaborCostPerSquareFoot = 100,
                MaterialCost = 4,
                ProductType = "Wood",
                State = "WA",
                Tax = 34,
                Total = 150,
                TaxRate = 5.0M
            };

            Order order3 = new Order
            {
                Area = 100,
                OrderDate = "20/20/2020",
                OrderNumber = 1,
                CostPerSquareFoot = 10,
                CustomerName = "JJ",
                LaborCost = 100,
                LaborCostPerSquareFoot = 100,
                MaterialCost = 4,
                ProductType = "Wood",
                State = "MN",
                Tax = 34,
                Total = 150,
                TaxRate = 5.0M
            };

            Order order4 = new Order
            {
                Area = 100,
                OrderDate = "20/20/2020",
                OrderNumber = 1,
                CostPerSquareFoot = 10,
                CustomerName = "",
                LaborCost = 100,
                LaborCostPerSquareFoot = 100,
                MaterialCost = 4,
                ProductType = "Wood",
                State = "WA",
                Tax = 34,
                Total = 150,
                TaxRate = 5.0M
            };

            Order order5 = new Order
            {
                Area = 100,
                OrderDate = "20/20/2020",
                OrderNumber = 1,
                CostPerSquareFoot = 10,
                CustomerName = "JJ",
                LaborCost = 100,
                LaborCostPerSquareFoot = 100,
                MaterialCost = 4,
                ProductType = "Fire",
                State = "WA",
                Tax = 34,
                Total = 150,
                TaxRate = 5.0M
            };

            OrderManager orderManager = new OrderManager(new OrderTestRepository());
            Assert.IsTrue(orderManager.AddOrder(order).Success);
            Assert.IsFalse(orderManager.AddOrder(order2).Success);
            Assert.IsFalse(orderManager.AddOrder(order3).Success);
            Assert.IsFalse(orderManager.AddOrder(order4).Success);
            Assert.IsFalse(orderManager.AddOrder(order5).Success);

            Assert.IsTrue(orderManager.LookupOder("20/20/2020").Orders.Last() == order);

        }

        [Test]
        public void CanEditOrder()
        {
            Order orderEdited = new Order
            {
                Area = 200,
                OrderDate = "01/01/2020",
                OrderNumber = 0,
                CostPerSquareFoot = 10,
                CustomerName = "JJ",
                LaborCost = 100,
                LaborCostPerSquareFoot = 100,
                MaterialCost = 4,
                ProductType = "Wood",
                State = "WA",
                Tax = 34,
                Total = 150,
                TaxRate = 5.0M
            };

            OrderManager orderManager = new OrderManager(new OrderTestRepository());
            Assert.IsTrue(orderManager.LookupOder("01/01/2020").Orders.Any(o => o.CustomerName == "Test Order"));
            Assert.IsTrue(orderManager.SaveEditedOrder(orderEdited));
            Assert.IsFalse(orderManager.LookupOder("01/01/2020").Orders.Any(o => o.CustomerName == "Test Order"));
            Assert.IsTrue(orderManager.LookupOder("01/01/2020").Orders.Where(or=>or.OrderNumber==0).All(o => o.CustomerName == "JJ"));
        }

        [Test]
        public void CanRemoveOrder()
        {
            OrderManager orderManager = new OrderManager(new OrderTestRepository());
            Assert.IsTrue(orderManager.LookupOder("01/01/2020").Orders.Any(o => o.OrderNumber == 4));
            Assert.IsTrue(orderManager.SaveWithoutRemovedOrder("01/01/2020", 4));
            Assert.IsFalse(orderManager.LookupOder("01/01/2020").Orders.Any(o => o.OrderNumber == 4));
        }
    }
}

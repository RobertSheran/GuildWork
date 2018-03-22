using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Response;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Test
{

    [TestFixture]
    public class FileOrderTests
    {
        [Test]
        public void CanEditOrderFromFile()
        {
            File.Copy(@"C:\Users\user\Documents\Data\Orders_06012019.test.txt", @"C:\Users\user\Documents\Data\Orders_06012019.txt");

            Order orderEdited = new Order
            {
                Area = 200,
                OrderDate = "06/01/2019",
                OrderNumber = 0,
                CostPerSquareFoot = 10,
                CustomerName = "JJ",
                LaborCost = 100,
                LaborCostPerSquareFoot = 100,
                MaterialCost = 4,
                ProductType = "Wood",
                State = "OH",
                Tax = 34,
                Total = 150,
                TaxRate = 5.0M
            };

            OrderManager orderManager = new OrderManager(new FileOrderRepository());
            orderManager.LookupOder("06/01/2019");
            Assert.IsTrue(orderManager.LookupOder("06/01/2019").Orders.Any(o => o.CustomerName == "Wise"));
            Assert.IsTrue(orderManager.SaveEditedOrder(orderEdited));
            Assert.IsFalse(orderManager.LookupOder("06/01/2019").Orders.Any(o => o.CustomerName == "Wise"));
            Assert.IsTrue(orderManager.LookupOder("06/01/2019").Orders.Where(or => or.OrderNumber == 0).All(o => o.CustomerName == "JJ"));
        }


        [Test]
        public void CanLoadOrdersTestFromFile()
        {
            OrderManager orderManager = new OrderManager(new FileOrderRepository());
            LookupOrdersResponse orderLookupResponse = orderManager.LookupOder("06/01/2019");
            Assert.IsTrue(orderLookupResponse.Success);
            orderLookupResponse = orderManager.LookupOder("01/02/2020");
            Assert.IsFalse(orderLookupResponse.Success);
        }


        [Test]
        public void CanLookupOrderTestFromFile()
        {
            OrderManager orderManager = new OrderManager(new FileOrderRepository());
            bool success = orderManager.LookupOder("06/01/2019").Success;
            bool fail = orderManager.LookupOder("01/02/9999").Success;
            Assert.IsTrue(success);
            Assert.IsFalse(fail);
        }

        


        //[Test]
        //public void CanLoadOrdersTestFromFile()
        //{
        //    OrderManager orderManager = new OrderManager(new FileOrderRepository());
        //    LookupOrdersResponse orderLookupResponse = orderManager.LookupOder("06/01/2019");
        //    Assert.IsTrue(orderLookupResponse.Success);
        //    orderLookupResponse = orderManager.LookupOder("01/02/2020");
        //    Assert.IsFalse(orderLookupResponse.Success);
        //}

        [Test]
        public void CanAddOrderTestFromFile()
        {
            Order order = new Order
            {
                Area = 100,
                OrderDate = "20/20/2020",
                CostPerSquareFoot = 10,
                CustomerName = "Koolio",
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

            OrderManager orderManager = new OrderManager(new FileOrderRepository());
            Assert.IsTrue(orderManager.AddOrder(order).Success);
            Assert.IsFalse(orderManager.AddOrder(order2).Success);
            Assert.IsFalse(orderManager.AddOrder(order3).Success);
            Assert.IsFalse(orderManager.AddOrder(order4).Success);
            Assert.IsFalse(orderManager.AddOrder(order5).Success);

            Assert.IsTrue(orderManager.LookupOder("20/20/2020").Orders.Any(o=>o.CustomerName=="Koolio"));

        }

       

        [Test]
        public void CanRemoveOrderFromFile()
        {
            OrderManager orderManager = new OrderManager(new FileOrderRepository());
            Assert.IsTrue(orderManager.LookupOder("06/01/2019").Orders.Any(o => o.OrderNumber == 2));
            Assert.IsTrue(orderManager.SaveWithoutRemovedOrder("06/01/2019", 2));
            Assert.IsFalse(orderManager.LookupOder("06/01/2019").Orders.Any(o => o.OrderNumber == 2));
        }

  
    }
}

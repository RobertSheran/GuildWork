using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            Exercise23();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var productsOutofStock = DataLoader.LoadProducts().Where(product => product.UnitsInStock == 0);

            PrintProductInformation(productsOutofStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var productsUnder3Bucks = DataLoader.LoadProducts().Where(product => product.UnitPrice > 3 && product.UnitsInStock > 0);

            PrintProductInformation(productsUnder3Bucks);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customersInWashington = DataLoader.LoadCustomers().Where(customer => customer.Region == "WA");

            PrintCustomerInformation(customersInWashington);


        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var justProductNames = from product in DataLoader.LoadProducts()
                                   select new
                                   {
                                       product.ProductName
                                   };

            foreach (var productName in justProductNames)
            {
                Console.WriteLine(productName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {

            var productsPricesInflated = from product in DataLoader.LoadProducts()
                                         select new
                                         {
                                             product.Category,
                                             product.ProductID,
                                             product.ProductName,
                                             NewPrice = product.UnitPrice * 1.25M,
                                             product.UnitsInStock
                                         };

            foreach (var product in productsPricesInflated)
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var productsNameAndCategoryUPPER = from product in DataLoader.LoadProducts()
                                               select new
                                               {
                                                   Category = product.Category.ToUpper(),
                                                   Name = product.ProductName.ToUpper()
                                               };

            foreach (var nameAndCategory in productsNameAndCategoryUPPER)
            {
                Console.WriteLine(nameAndCategory);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {

            var productWithReStockBool = from product in DataLoader.LoadProducts()
                                         select new
                                         {
                                             OutOfStock = product.UnitsInStock < 3,
                                             product.UnitsInStock,
                                             product.UnitPrice,
                                             product.ProductName,
                                             product.ProductID,
                                             product.Category
                                         };

            foreach (var product in productWithReStockBool)
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var productsWithStockValue = from product in DataLoader.LoadProducts()
                                         select new
                                         {
                                             product.Category,
                                             product.ProductID,
                                             product.ProductName,
                                             product.UnitPrice,
                                             product.UnitsInStock,
                                             StockValue = product.UnitsInStock * product.UnitPrice
                                         };
            foreach (var product in productsWithStockValue)
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var EvenNumbers = DataLoader.NumbersA.Where(number => number % 2 == 0);

            foreach (var evenNumber in EvenNumbers)
            {
                Console.WriteLine(evenNumber);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var customersWithOrderUnder500 = DataLoader.LoadCustomers()
                .Where(customer => customer.Orders.Any(order => order.Total < 500));

            PrintCustomerInformation(customersWithOrderUnder500);

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var oddsFirst3 = DataLoader.NumbersC.Where(number => number % 2 != 0).Take(3);

            foreach (var odd in oddsFirst3)
            {
                Console.WriteLine(odd);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var notLast3 = DataLoader.NumbersB.Take(DataLoader.NumbersB.Length - 3);

            foreach (var number in notLast3)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var companysAndRecentOrderWA = from customer in DataLoader.LoadCustomers().Where(customer => customer.Region == "WA")
                                           select new
                                           {
                                               customer.CompanyName,
                                               RecentOrder = customer.Orders.Last().OrderID
                                           };

            foreach (var companyAndRecentOrderWA in companysAndRecentOrderWA)
            {
                Console.WriteLine(companyAndRecentOrderWA);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var allTill6 = DataLoader.NumbersC.TakeWhile(number => number < 6);

            foreach (var number in allTill6)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var takeAfterDiv3 = DataLoader.NumbersC.SkipWhile(number => number % 3 != 0).Skip(1);

            foreach (var number in takeAfterDiv3)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var productsAlphabeticaly = DataLoader.LoadProducts().OrderBy(product => product.ProductName);

            PrintProductInformation(productsAlphabeticaly);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var productsDecendingUnitsInStock = DataLoader.LoadProducts().OrderByDescending(product => product.UnitsInStock);

            PrintProductInformation(productsDecendingUnitsInStock);

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var productsByCatThenPriceHigh = DataLoader.LoadProducts()
            .OrderBy(product => product.Category)
            .ThenByDescending(product => product.UnitPrice);

            PrintProductInformation(productsByCatThenPriceHigh);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var bReversed = DataLoader.NumbersB.Reverse();

            foreach (var number in bReversed)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var products = DataLoader.LoadProducts().GroupBy(product => product.Category);

            foreach (var group in products)
            {
                Console.WriteLine();
                Console.WriteLine("\t" + group.Key);

                foreach (var product in group)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
        }

        /// <summary>
        ///// Print all Customers with their orders by Year then Month
        ///// ex:
        ///// 
        ///// Joe's Diner
        ///// 2015
        /////     1 -  $500.00
        /////     3 -  $750.00
        ///// 2016
        /////     2 - $1000.00
        ///// </summary>
        //static void Exercise21()
        //{

        //}

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var productCategories = DataLoader.LoadProducts().GroupBy(product => product.Category);

            foreach (var group in productCategories)
            {
                Console.WriteLine(group.Key);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var products = DataLoader.LoadProducts().GroupBy(product => product.ProductID);

            foreach (var key in products)
            {
                if (key.Key == 789)
                {
                    Console.WriteLine("yeah, its there");
                }
            }

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var categoriesItemOutOfStock = DataLoader.LoadProducts()
                .Where(product => product.UnitsInStock == 0)
                .GroupBy(product => product.Category);

            foreach (var group in categoriesItemOutOfStock)
            {
                Console.WriteLine(group.Key);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var categoriesNoProductsOut = DataLoader.LoadProducts()
                .GroupBy(product => product.Category)
                .Where(groups => groups.All(product => product.UnitsInStock > 0));

            foreach (var group in categoriesNoProductsOut)
            {
                Console.WriteLine(group.Key);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var numberOfOdds = DataLoader.NumbersA.Where(number => number % 2 != 0);

            Console.WriteLine(numberOfOdds.Count());
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var numberOfOrdersWithID = from customer in DataLoader.LoadCustomers()
                                       select new
                                       {
                                           customer.CustomerID,
                                           OrderCount = customer.Orders.Count()
                                       };

            foreach (var customer in numberOfOrdersWithID)
            {
                Console.WriteLine(customer);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var productCategoriesWithProductCount = from product in DataLoader.LoadProducts().GroupBy(product => product.Category)
                                                    select new
                                                    {
                                                        Category = product.Key,
                                                        CategoryCount = product.Count()
                                                    };

            foreach (var group in productCategoriesWithProductCount)
            {
                Console.WriteLine(group);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var productCategoriesWithStockCount = from product in DataLoader.LoadProducts().GroupBy(product => product.Category)
                                                  select new
                                                  {
                                                      Category = product.Key,
                                                      UnitsTotal = product.Sum(stock => stock.UnitsInStock)
                                                  };

            foreach (var group in productCategoriesWithStockCount)
            {
                Console.WriteLine(group);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var categoriesWithLowestPricedProduct = from product in DataLoader.LoadProducts().GroupBy(product => product.Category)
                                                    select new
                                                    {
                                                        Category = product.Key,
                                                        LowestPricedProduct = product.OrderBy(p => p.UnitPrice).Select(lowestProduct => lowestProduct.ProductName).Last()
                                                    };

            foreach (var group in categoriesWithLowestPricedProduct)
            {
                Console.WriteLine(group);
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var threeTopCategoriesByAvgUnitPrice = from product in DataLoader.LoadProducts().GroupBy(product => product.Category)
                                                   select new
                                                   {
                                                       Category = product.Key,
                                                       AvgUnitPrice = product.Sum(productPrice => productPrice.UnitPrice) / product.Count()
                                                   };

            foreach (var group in threeTopCategoriesByAvgUnitPrice.OrderByDescending(productAvg => productAvg.AvgUnitPrice).Take(3))
            {
                Console.WriteLine(group);
            }
        }
    }
}

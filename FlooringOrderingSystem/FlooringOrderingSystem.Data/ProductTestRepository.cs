using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Interface;
using System.Collections.Generic;

namespace FlooringOrderingSystem.Data
{
    public class ProductTestRepository : IProductRepository
    {
        private static Product _product = new Product
        {
            ProductType = "Wood",
            CostPerSquareFoot = 33.3M,
            LaborCostPerSquareFoot = 6.44M
        };
        private static Product _product2 = new Product
        {
            ProductType = "Tile",
            CostPerSquareFoot = 23.3M,
            LaborCostPerSquareFoot = 2.44M
        };
        private static Product _product3 = new Product
        {
            ProductType = "Dirt",
            CostPerSquareFoot = 3.3M,
            LaborCostPerSquareFoot = 1.44M
        };

        public IEnumerable<Product> LoadProducts()
        {
            IEnumerable<Product> list = new List<Product>
            {
                _product,
                _product2,
                _product3
            };
            return list;
        }
    }
}

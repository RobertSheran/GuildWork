using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Interface;
using System.Collections.Generic;
using System.IO;

namespace FlooringOrderingSystem.Data
{
    public class FileProductRepository : IProductRepository
    {
        private string _filePath;

        public FileProductRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Product> _products;

        public void GetProductsFromFile()
        {
            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                List<Product> products = new List<Product>();
                string line = "";
                streamReader.ReadLine();
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    Product product = new Product
                    {
                        ProductType = columns[0],
                        LaborCostPerSquareFoot = decimal.Parse(columns[1]),
                        CostPerSquareFoot = decimal.Parse(columns[2])
                    };
                    products.Add(product);
                }
                _products = products;
            }
        }

        public IEnumerable<Product> LoadProducts()
        {
            GetProductsFromFile();
            return _products;
        }
    }
}
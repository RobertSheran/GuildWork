using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Interface;
using FlooringOrderingSystem.Modles.Response;
using System.Collections.Generic;

namespace FlooringOrderingSystem.BLL
{
    public class ProductManager
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> ListProducts()
        {  
            return _productRepository.LoadProducts();
        }
    }
}
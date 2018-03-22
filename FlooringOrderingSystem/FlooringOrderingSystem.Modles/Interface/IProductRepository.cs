using System.Collections.Generic;

namespace FlooringOrderingSystem.Modles.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> LoadProducts();
    }
}

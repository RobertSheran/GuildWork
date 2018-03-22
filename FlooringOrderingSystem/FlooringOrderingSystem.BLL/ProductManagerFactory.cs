using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.Modles;
using System;
using System.Configuration;

namespace FlooringOrderingSystem.BLL
{
    public class ProductManagerFactory
    {
        public static ProductManager Create()
        {

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "Test":
                    return new ProductManager(new ProductTestRepository());
                case "File":
                    return new ProductManager(new FileProductRepository(Settings.filePathProducts));
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}

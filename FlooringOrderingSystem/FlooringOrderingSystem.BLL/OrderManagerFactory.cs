using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.Modles;
using System;
using System.Configuration;

namespace FlooringOrderingSystem.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "Test":
                    return new OrderManager(new OrderTestRepository());
                case "File":
                    return new OrderManager(new FileOrderRepository());
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}

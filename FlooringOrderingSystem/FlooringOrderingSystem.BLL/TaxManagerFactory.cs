using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.Modles;
using System;
using System.Configuration;

namespace FlooringOrderingSystem.BLL
{
    public class TaxManagerFactory
    {
        public static TaxManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "Test":
                    return new TaxManager(new TaxTestRepository());
                case "File":
                    return new TaxManager(new FileTaxRepository(Settings.filePathTaxs));
                default:
                    Console.WriteLine("Mode not supported");
                    break;
            }
            throw new NotImplementedException();
        }
    }
}

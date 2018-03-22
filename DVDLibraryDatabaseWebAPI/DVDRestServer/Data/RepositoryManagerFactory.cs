using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RepositoryManagerFactory
    {
        public static RepositoryManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "InMemoryRepository":
                    return new RepositoryManager(new InMemoryRepository());
                case "ADORepository":
                    return new RepositoryManager(new ADORepository());
                case "EFRepository":
                    return new RepositoryManager(new EFRepository());
                default:
                    throw new NotImplementedException();
            }
        }        
    }
}

using CarDealership.BLL.Managers;
using CarDealership.Models.IRepositories;
using Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.InMemoryRepos;


namespace CarDealership.BLL.Factories
{
    public class RepositoryManagerFactory
    {
        public static RepositoryManager Create()
        {
            string mode = Settings.Mode;
            switch (mode)
            {
                case "ADO":
                    return new RepositoryManager(new ColorRepository(),  new BodyStyleRepository(),  new CarModelRepository(), new CarsRepository(), new CarTypeRepository(), new InteriorColorRepository(), new MakeRepository(), new TransmissionRepository());
                case "IM":
                    return new RepositoryManager(new IMColorRepo(), new IMBodyStyleRepo(), new IMCarModelRepo(), new IMCarsRepo(), new IMCarTypeRepo(), new IMIntiriorColorRepo(), new IMMakeRepo(), new IMTransmissionRepo());
                default:
                    throw new Exception("Could not find a valid repo configuration.");
            }
        }
    }
}

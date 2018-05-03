using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemoryRepos
{
    public class IMCarTypeRepo : ICarTypeRepository
    {
        List<CarType> carTypes = new List<CarType>()
        {
            new CarType()
            {
                CarTypeId = 1,
                CarTypeName = "T1"
            },
            new CarType()
            {
                CarTypeId = 2,
                CarTypeName = "T2"
            }

        };
        public void Add(CarType bodyStyle)
        {
            carTypes.Add(bodyStyle);
        }

        public CarType Get(int id)
        {
           return carTypes.Where(c => c.CarTypeId == id).FirstOrDefault();

        }

        public List<CarType> GetAll()
        {
            return carTypes;
        }

        public void Remove(int id)
        {
            carTypes.Remove(carTypes.Where(c => c.CarTypeId == id).FirstOrDefault());
        }
    }
}

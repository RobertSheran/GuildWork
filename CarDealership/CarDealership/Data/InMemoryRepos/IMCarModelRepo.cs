using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemoryRepos
{
    public class IMCarModelRepo : ICarModelRepository
    {
        List<CarModel> carModels = new List<CarModel>()
        {
            new CarModel()
            {
                CarModelId = 1,
                CarModelName = "m1",
                MakeId = 1
            },
            new CarModel()
            {
                CarModelId = 2,
                CarModelName = "m2",
                MakeId = 1
            },
            new CarModel()
            {
                CarModelId = 3,
                CarModelName = "m3",
                MakeId = 1
            },
            new CarModel()
            {
                CarModelId = 4,
                CarModelName = "m4",
                MakeId = 2
            },
            new CarModel()
            {
                CarModelId = 5,
                CarModelName = "m5",
                MakeId = 2
            },
            new CarModel()
            {
                CarModelId = 6,
                CarModelName = "m6",
                MakeId = 2
            },
            new CarModel()
            {
                CarModelId = 7,
                CarModelName = "m7",
                MakeId = 3
            },
            new CarModel()
            {
                CarModelId = 8,
                CarModelName = "m8",
                MakeId = 3
            },
            new CarModel()
            {
                CarModelId = 9,
                CarModelName = "m9",
                MakeId = 3
            },
        };

        List<Special> specials = new List<Special>()
        {
            new Special()
            {
                SpecialId = 1,
                SpecialMessage = "s1"
            },
            new Special()
            {
                SpecialId = 2,
                SpecialMessage = "s2"
            },
            new Special()
            {
                SpecialId = 3,
                SpecialMessage = "s3"
            },
        };

        public void Add(CarModel carModel)
        {
            carModels.Add(carModel);
        }

        public void AddDeal(Special special)
        {
            specials.Add(special);     
        }

        public CarModel Get(int id)
        {
            return carModels.Where(c => c.CarModelId == id).FirstOrDefault();
        }

        public List<CarModel> GetAll()
        {
            return carModels;
        }

        public List<Special> GetSpecialOffers()
        {
            return specials;
        }

        public void Remove(int id)
        {

            CarModel carModel = carModels.Where(c => c.CarModelId == id).FirstOrDefault();
            carModels.Remove(carModel);
        }

        public void RemoveDeal(int id)
        {
            specials.Remove(specials.Where(s => s.SpecialId == id).FirstOrDefault());
        }
    }
}

using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemoryRepos
{
    public class IMMakeRepo : IMakeRepository
    {
        List<Make> makes = new List<Make>()
        {
            new Make()
            {
                MakeId = 1,
                MakeName = "M1",
            },
             new Make()
            {
                MakeId = 2,
                MakeName = "M2",
            },
              new Make()
            {
                MakeId = 3,
                MakeName = "M3",
            }
        };
        public void Add(Make make)
        {
            makes.Add(make);
        }

        public Make Get(int id)
        {
            return makes.Where(m => m.MakeId == id).FirstOrDefault();
        }

        public List<Make> GetAll()
        {
            return makes;
        }

        public void Remove(int id)
        {
            makes.Remove(makes.Where(m => m.MakeId == id).FirstOrDefault());
        }
    }
}

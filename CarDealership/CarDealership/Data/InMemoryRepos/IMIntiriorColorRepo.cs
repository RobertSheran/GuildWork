using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemoryRepos
{
    public class IMIntiriorColorRepo : IInteriorColorRepository
    {
        List<InteriorColors> interiorColors = new List<InteriorColors>()
        {
            new InteriorColors()
            {
                InteriorColorId = 1,
                InteriorColorName = "I1"
            },
             new InteriorColors()
            {
                InteriorColorId = 2,
                InteriorColorName = "I2"
            },
              new InteriorColors()
            {
                InteriorColorId = 3,
                InteriorColorName = "I3"
            }
        };

        public void Add(InteriorColors interiorColor)
        {
            interiorColors.Add(interiorColor);
        }

        public InteriorColors Get(int id)
        {
           return interiorColors.Where(c => c.InteriorColorId == id).FirstOrDefault();
    }

        public List<InteriorColors> GetAll()
        {
            return interiorColors;
        }

        public void Remove(int id)
        {
            interiorColors.Remove(interiorColors.Where(c => c.InteriorColorId == id).FirstOrDefault());
        }
    }
}

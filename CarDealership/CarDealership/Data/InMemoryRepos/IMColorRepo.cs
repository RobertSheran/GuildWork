using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemoryRepos
{
    public class IMColorRepo : IColorRepository
    {
        List<Color> colors = new List<Color>()
        {
            new Color()
            {
                ColorId = 1,
                ColorName ="c1"
            },
            new Color()
            {
                ColorId = 2,
                ColorName ="c2"
            },
             new Color()
            {
                ColorId = 3,
                ColorName ="c3"
            }

        };
        public void Add(Color color)
        {
            colors.Add(color);
        }

        public Color Get(int id)
        {
            return colors.Where(c => c.ColorId == id).FirstOrDefault();
        }

        public List<Color> GetAll()
        {
            return colors;
        }

        public void Remove(int id)
        {
            colors.Remove(colors.Where(c => c.ColorId == id).FirstOrDefault());
        }
    }
}

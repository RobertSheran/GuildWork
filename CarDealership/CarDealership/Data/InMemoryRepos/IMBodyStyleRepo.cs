using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemoryRepos
{
    public class IMBodyStyleRepo : IBodyStyleRepository
    {
        List<BodyStyle> bodyStyles = new List<BodyStyle>()
        {
            new BodyStyle()
            {
                BodyStyleId =1,
                BodyStyleName ="bs1"
            },
            new BodyStyle()
            {
                BodyStyleId = 2,
                BodyStyleName ="bs2"
            },
             new BodyStyle()
            {
                BodyStyleId = 3,
                BodyStyleName ="bs3"
            }

        };

        public void Add(BodyStyle bodyStyle)
        {
            bodyStyles.Add(bodyStyle);
        }

        public BodyStyle Get(int id)
        {
            return bodyStyles.Where(b => b.BodyStyleId == id).FirstOrDefault();
        }

        public List<BodyStyle> GetAll()
        {
            return bodyStyles;        
        }

        public void Remove(int id)
        {
            BodyStyle style = bodyStyles.Where(b => b.BodyStyleId == id).FirstOrDefault();
            bodyStyles.Remove(style);
        }
    }
}

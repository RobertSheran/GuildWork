using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.IRepositories
{
    public interface IBodyStyleRepository
    {
        void Add(BodyStyle bodyStyle);
        void Remove(int id);
        List<BodyStyle> GetAll();
        BodyStyle Get(int id);
    }
}

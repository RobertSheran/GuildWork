using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.IRepositories
{
    public interface IColorRepository
    {
        void Add(Color color);
        void Remove(int id);
        List<Color> GetAll();
        Color Get(int id);
    }
}

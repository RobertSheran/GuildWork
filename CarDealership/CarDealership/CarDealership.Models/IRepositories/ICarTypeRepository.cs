using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.IRepositories
{
    public interface ICarTypeRepository
    {
        void Add(CarType bodyStyle);
        void Remove(int id);
        List<CarType> GetAll();
        CarType Get(int id);
    }
}

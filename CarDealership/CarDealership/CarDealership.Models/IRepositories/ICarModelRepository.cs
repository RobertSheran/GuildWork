using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.IRepositories
{
    public interface ICarModelRepository
    {
        void AddDeal(Special special);
        void RemoveDeal(int id);
        List<Special> GetSpecialOffers();
        void Add(CarModel carModel);
        void Remove(int id);
        List<CarModel> GetAll();
        CarModel Get(int id);
    }
}

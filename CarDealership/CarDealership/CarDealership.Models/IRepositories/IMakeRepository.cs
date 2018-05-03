using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.IRepositories
{
    public interface IMakeRepository
    {
        void Add(Make make);
        void Remove(int id);
        List<Make> GetAll();
        Make Get(int id);
    }
}

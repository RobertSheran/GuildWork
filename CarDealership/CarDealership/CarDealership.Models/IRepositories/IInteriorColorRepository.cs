using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.IRepositories
{
    public interface IInteriorColorRepository
    {
        void Add(InteriorColors interiorColor);
        void Remove(int id);
        List<InteriorColors> GetAll();
        InteriorColors Get(int id);
    }
}

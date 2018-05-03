using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.IRepositories
{
    public interface ITransmissionRepository
    {
        void Add(Transmission transmission);
        void Remove(int id);
        List<Transmission> GetAll();
        Transmission Get(int id);
    }
}

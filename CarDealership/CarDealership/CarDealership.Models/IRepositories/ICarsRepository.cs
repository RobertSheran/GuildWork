using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.IRepositories
{
    public interface ICarsRepository
    {
       
        void AddFinancing(string financing);
        List<Financing> GetFinancing();
        void AddState(State state);
        List<State> GetStates();
        void AddInvoice(Invoice invoice);
        List<Contact> GetAllMessages();
        void AddMessage(Contact contact);
        void RemoveMessage(int id);
        List<Cars> GetAllUsed();
        List<Cars> GetAllNew();
        void Add(Cars car);
        void Edit(Cars car);
        void Remove(int id);
        void MarkSold(int id);
        void MarkSpecial(int id);
        List<Cars> GetAllSold();
        List<Cars> GetAll();
        Cars Get(int id);
        List<Cars> GetAllSpecial();
        List<Cars> GetByMake(int id);
        List<Cars> GetByModel(int id);
        List<Cars> GetByYear(int year);
        List<Cars> GetByPrice(int low, int high);
        IEnumerable<ShortCar> Search(ListingSearchPerameters perameters);
        IEnumerable<ShortCar> SearchNew(ListingSearchPerameters perameters);
        IEnumerable<ShortCar> SearchUsed(ListingSearchPerameters perameters);

    }
}

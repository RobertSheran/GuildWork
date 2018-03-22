using FlooringOrderingSystem.Modles.Response;
using System.Collections.Generic;

namespace FlooringOrderingSystem.Modles.Interface
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(string orderDate);
        bool SaveNewOrder(Order order);
        bool SaveEditedOrder(Order order);
        bool SaveWithoutRemovedOrder(int orderNumber,string date);
        string CheckDateExists(string date);
        string CheckEditAddOrderNumber(string orderNumber,string orderDate);
    }
}

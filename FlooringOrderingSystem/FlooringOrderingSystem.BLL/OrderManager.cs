using FlooringOrderingSystem.Modles;
using FlooringOrderingSystem.Modles.Interface;
using FlooringOrderingSystem.Modles.Response;
using System.Linq;

namespace FlooringOrderingSystem.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public string GetValidDate(string userInput)
        {

            return _orderRepository.CheckDateExists(userInput);
        }

        public string GetValidOrderNumber(string userInput, string orderDate)
        {
         
            return _orderRepository.CheckEditAddOrderNumber(userInput, orderDate);
        }

        public bool SaveEditedOrder(Order order)
        {
            return (_orderRepository.SaveEditedOrder(order));
        }

        public bool SaveWithoutRemovedOrder(string date, int orderNumber)
        {
            return _orderRepository.SaveWithoutRemovedOrder(orderNumber, date);
        }

        public AddOrderResponse AddOrder(Order order)
        {
            AddOrderResponse addOrderResponse = new AddOrderResponse();
            TaxManager taxManager = TaxManagerFactory.Create();
            ProductManager productManager = ProductManagerFactory.Create();
            if (order.CustomerName.Length == 0)
            {
                addOrderResponse.Message = "ERROR: Must Enter A Name";
                addOrderResponse.OrderToAdd = null;
                addOrderResponse.Success = false;
                return addOrderResponse;
            }
            if (order.Area < 100)
            {
                addOrderResponse.Message = "ERROR: Must Enter An Area>99 Square Feet";
                addOrderResponse.OrderToAdd = null;
                addOrderResponse.Success = false;
                return addOrderResponse;
            }
            if (!taxManager.LookupTax(order.State).Any(state => state.StateAbbreviation == order.State))
            {
                addOrderResponse.Message = "ERROR: Must Enter An Supported State";
                addOrderResponse.OrderToAdd = null;
                addOrderResponse.Success = false;
                return addOrderResponse;
            }
            if (!productManager.ListProducts().Any(product => product.ProductType == order.ProductType))
            {
                addOrderResponse.Message = "ERROR: Must Enter An Supported Product Type";
                addOrderResponse.OrderToAdd = null;
                addOrderResponse.Success = false;
                return addOrderResponse;
            }

         
            else if (order.CustomerName.Any(charactor => charactor == ','))
            {
                addOrderResponse.Success = false;
                addOrderResponse.Message = "ERROR: Customer Name does NOT support commas";
                addOrderResponse.OrderToAdd = null;
            }

            else
            {
                addOrderResponse.Success = true;
                addOrderResponse.OrderToAdd = order;
                addOrderResponse.Orders = _orderRepository.LoadOrders(order.OrderDate);
                addOrderResponse.Message = "Success";
                _orderRepository.SaveNewOrder(order);
            };

            return addOrderResponse;
        }

        public LookupOrdersResponse LookupOder(string orderDate)
        {
            LookupOrdersResponse orderLookupResponse = new LookupOrdersResponse();
            var _orders = _orderRepository.LoadOrders(orderDate);

            if (_orders==null||_orders.FirstOrDefault() == null)
            {
                orderLookupResponse.Message = (orderDate + " has no orders. \nFormat: MM/dd/yyyy");
                orderLookupResponse.Orders = null;
                orderLookupResponse.Success = false;
            } 
            else
            {
                orderLookupResponse.Message = "Success";
                orderLookupResponse.Orders = _orders;
                orderLookupResponse.Success = true;
            }
            
            return orderLookupResponse;
        }
    }
}

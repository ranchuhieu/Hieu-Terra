using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.DataStore.HardCode
{
    public class OrderRepository : IOrderRespository
    {
        private Dictionary<int, Order> _order;
        public OrderRepository() { 
            _order = new Dictionary<int, Order>();
        }
        public int CreateOrder(Order order)
        {
            // throw new NotImplementedException();
            order.OrderId = _order.Count + 1;
            //order.UniqueId=Guid.NewGuid().ToString(); 
            _order.Add(order.OrderId.Value, order);
            return order.OrderId.Value;
        }

        public IEnumerable<Order> GetLineItemsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
           // throw new NotImplementedException();
            return _order[id];
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            //throw new NotImplementedException();
            foreach (var order in _order)
            {
                if (order.Value.UniqueId == uniqueId) return order.Value;
                
            }
            return null;
        }

        public IEnumerable<Order> GetOrders()
        {
            //throw new NotImplementedException();
            return _order.Values;
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            //throw new NotImplementedException();
            var allOrders=(IEnumerable<Order>) _order.Values;
            return allOrders.Where(x=>x.DateProcessed.HasValue==false);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            //throw new NotImplementedException();
            var allOrders = (IEnumerable<Order>)_order.Values;
            return allOrders.Where(x => x.DateProcessed.HasValue);
        }

        public void UpdateOrder(Order order)
        {
            //throw new NotImplementedException();
            if (order == null || !order.OrderId.HasValue) return;
            var ord = _order[order.OrderId.Value];
            if (ord == null)
                return;
            _order[order.OrderId.Value] = order;
        }

        IEnumerable<OrderLineItem> IOrderRespository.GetLineItemsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}

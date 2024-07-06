using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.DataStore.HardCodes.Helper;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BanHangHieuTerraum.DataStore.SQL.Dapper
{
    public class OrderRepository : IOrderRespository
    {
        private readonly IDataAccess _dataAccess;
        public OrderRepository(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }
        public int CreateOrder(Order order)
        {
            //throw new NotImplementedException();
            var sql = @"insert into [dbo].[Order] 
            ([DatePlaced],[DateProcessing],[DateProcessed],[CustomerName],[CustomerAddress],[CustomerCity],[CustomerStateProvince],[CustomerCountry],[AdminUser],[UniqueId])
             output inserted.OrderId
             values(@DatePlaced,@DateProcessing,@DateProcessed,@CustomerName,@CustomerAddress,@CustomerCity,@CustomerStateProvince,@CustomerCountry,@AdminUser,@UniqueId)";
            var orderId = _dataAccess.QuerySingle<int, Order>(sql, order);

            sql = @"insert into [dbo].[OrderLineItem]
                    ([ProductId]
                     ,[OrderId]
                     ,[Quantity]
                     ,[Price])
                   values
                       (@ProductId, @OrderId, @Quantity, @Price)";

            //create line items
            order.LineItems.ForEach(x => x.OrderId = orderId);
            _dataAccess.ExecuteCommand(sql, order.LineItems);
            return orderId;

        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            //throw new NotImplementedException();
            var sql = @"select * from OrderLineItem where OrderId = @OrderId";
            var lineItems = _dataAccess.Query<OrderLineItem, dynamic>(sql, new { OrderId = orderId });

            sql = @"select * from Product where Id = @Id";
            lineItems.ForEach(x => x.Product = _dataAccess.QuerySingle<Product, dynamic>(sql, new { Id = x.ProductId }));
            return lineItems;
        }

        public Order GetOrder(int id)
        {
            //throw new NotImplementedException();
            var sql = "select * from [Order] where OrderId  = @OrderId";
            var order = _dataAccess.QuerySingle<Order, dynamic>(sql, new { OrderId = id });
            order.LineItems = GetLineItemsByOrderId(order.OrderId.Value).ToList();
            return order;
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            // throw new NotImplementedException();
            var sql = "select * from [Order] where UniqueId  = @UniqueId";
            var order = _dataAccess.QuerySingle<Order, dynamic>(sql, new { UniqueId = uniqueId });
            order.LineItems = GetLineItemsByOrderId(order.OrderId.Value).ToList();
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            // throw new NotImplementedException();
            return _dataAccess.Query<Order, dynamic>("select * from [Order]", new { });
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            //throw new NotImplementedException();
            var sql = "select * from [Order] where DateProcessed is null";
            return _dataAccess.Query<Order, dynamic>(sql, new { });
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            //throw new NotImplementedException();
            var sql = "select * from [Order] where DateProcessed is not null";
            return _dataAccess.Query<Order, dynamic>(sql, new { });
        }

        public void UpdateOrder(Order order)
        {
            // throw new NotImplementedException();
            var sql = @"UPDATE [Order]
                     SET   [DatePlaced] = @DatePlaced
                          ,[DateProcessing] = @DateProcessing
                          ,[DateProcessed] = @DateProcessed
                          ,[CustomerName] = @CustomerName
                          ,[CustomerAddress] = @CustomerAddress
                          ,[CustomerCity] = @CustomerCity
                          ,[CustomerStateProvince] = @CustomerStateProvince
                          ,[CustomerCountry] = @CustomerCountry
                          ,[AdminUser] = @AdminUser
                          ,[UniqueId] = @UniqueId
                     WHERE OrderId = @OrderId";
            _dataAccess.ExecuteCommand<Order>(sql, order);

            //update line items
            sql = @"UPDATE [OrderLineItem]
                  SET   [ProductId] = @ProductId
                        ,[OrderId] = @OrderId
                        ,[Quantity] = @Quantity
                        ,[Price] = @Price
                  WHERE LineItemId = @LineItemId";
            _dataAccess.ExecuteCommand<List<OrderLineItem>>(sql, order.LineItems);
        }
    }
}

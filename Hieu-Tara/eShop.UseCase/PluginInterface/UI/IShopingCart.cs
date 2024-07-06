using BanHangHieuTerraum.CoreBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.UseCase.PluginInterface.UI
{
    //Shoping Cart có giá trị tạm thời
    public interface IShopingCart
    {
        Task<Order> GetOrderAsync();
        Task<Order> AddProductAsync(Product product);
        Task<Order> UpdateQuantityAsync(int productId,int quatity);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> DeleteProductAsync(int productId);
        Task<Order> PlaceOrderAsync();
        Task EmptyAsync();
    }
}

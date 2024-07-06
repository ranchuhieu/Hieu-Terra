using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.CoreBusiness.Service.Interfaces;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;
using BanHangHieuTerraum.UseCase.PluginInterface.StateStore;
using BanHangHieuTerraum.UseCase.PluginInterface.UI;
using BanHangHieuTerraum.UseCase.ShoppingCartScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.UseCase.ShoppingCartScreen
{
    public class PlaceOrderUserCase : IPlaceOrderUserCase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRespository _orderRespository;
        private readonly IShopingCart _shopingCart;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;
        public PlaceOrderUserCase(IOrderService orderService,
            IOrderRespository orderRespository,
            IShopingCart shopingCart,
            IShoppingCartStateStore shoppingCartStateStore)
        {
            this._orderService = orderService;
            this._orderRespository = orderRespository;
            this._shopingCart = shopingCart;
            this._shoppingCartStateStore = shoppingCartStateStore;
        }
        public async Task<string> Execute(Order order)
        {
            if (_orderService.ValidateCreateOrder(order))
            {
                order.DatePlaced = DateTime.Now;
              
                order.UniqueId = Guid.NewGuid().ToString();
                _orderRespository.CreateOrder(order);

                await _shopingCart.EmptyAsync();
                _shoppingCartStateStore.UpdateLineItemsCount();
                return order.UniqueId;
            }
            return null;
        }

    }
}

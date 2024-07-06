using BanHangHieuTerraum.CoreBusiness.Model;
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

    public class DeleteProductUserCase : IDeleteProductUserCase
    {
        private readonly IShopingCart _shoppingcart;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;
        public DeleteProductUserCase(IShopingCart shopingCart, IShoppingCartStateStore shoppingCartStateStore)
        {

            this._shoppingcart = shopingCart;
            this._shoppingCartStateStore = shoppingCartStateStore;
        }
        public async Task<Order> Execute(int productId)
        {
            var order = await this._shoppingcart.DeleteProductAsync(productId);
            this._shoppingCartStateStore.UpdateLineItemsCount();
            return order;
        }
    }
}

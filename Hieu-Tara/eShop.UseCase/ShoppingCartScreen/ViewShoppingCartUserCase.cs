using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.UseCase.PluginInterface.UI;
using BanHangHieuTerraum.UseCase.ShoppingCartScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.UseCase.ShoppingCartScreen
{
    public class ViewShoppingCartUserCase : IViewShoppingCartUserCase
    {
        //khai báo
        private readonly IShopingCart _shoppingCart;

        //khởi tạo
        public ViewShoppingCartUserCase(IShopingCart shopingCart)
        {
            this._shoppingCart = shopingCart;
        }
        public Task<Order> Execute()
        {
            return _shoppingCart.GetOrderAsync();
        }
    }
}

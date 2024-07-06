using BanHangHieuTerraum.CoreBusiness.Model;

namespace BanHangHieuTerraum.UseCase.ShoppingCartScreen.Interfaces
{
    public interface IViewShoppingCartUserCase
    {
        Task<Order> Execute();
    }
}
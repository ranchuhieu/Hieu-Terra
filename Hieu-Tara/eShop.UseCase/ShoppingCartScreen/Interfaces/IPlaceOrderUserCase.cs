using BanHangHieuTerraum.CoreBusiness.Model;

namespace BanHangHieuTerraum.UseCase.ShoppingCartScreen.Interfaces
{
    public interface IPlaceOrderUserCase
    {
        Task<string> Execute(Order order);
    }
}
using BanHangHieuTerraum.CoreBusiness.Model;

namespace BanHangHieuTerraum.UseCase.ShoppingCartScreen.Interfaces
{
    public interface IUpdateQuantityUserCase
    {
        Task<Order> Execute(int productId, int quatity);
    }
}
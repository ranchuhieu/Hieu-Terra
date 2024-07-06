using BanHangHieuTerraum.CoreBusiness.Model;

namespace BanHangHieuTerraum.UseCase.ShoppingCartScreen.Interfaces
{
    public interface IDeleteProductUserCase
    {
        Task<Order> Execute(int productId);
    }
}
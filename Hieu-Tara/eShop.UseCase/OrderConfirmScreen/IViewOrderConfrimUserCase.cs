using BanHangHieuTerraum.CoreBusiness.Model;

namespace BanHangHieuTerraum.UseCase.OrderConfirmScreen
{
    public interface IViewOrderConfrimUserCase
    {
        Order Execute(string uniqueId);
    }
}
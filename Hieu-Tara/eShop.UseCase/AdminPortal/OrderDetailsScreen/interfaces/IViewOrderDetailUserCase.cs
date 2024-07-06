using BanHangHieuTerraum.CoreBusiness.Model;

namespace BanHangHieuTerraum.UseCase.AdminPortal.OrderDetailsScreen.interfaces
{
    public interface IViewOrderDetailUserCase
    {
        Order Execute(int orderId);
    }
}
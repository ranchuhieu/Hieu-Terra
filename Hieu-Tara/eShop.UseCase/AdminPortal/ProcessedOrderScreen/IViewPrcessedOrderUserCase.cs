using BanHangHieuTerraum.CoreBusiness.Model;

namespace BanHangHieuTerraum.UseCase.AdminPortal.ProcessedOrderScreen
{
    public interface IViewPrcessedOrderUserCase
    {
        IEnumerable<Order> Execute();
    }
}
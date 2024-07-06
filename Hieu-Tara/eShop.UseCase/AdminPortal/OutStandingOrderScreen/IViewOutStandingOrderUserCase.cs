using BanHangHieuTerraum.CoreBusiness.Model;

namespace BanHangHieuTerraum.UseCase.AdminPortal.OutStandingOrderScreen
{
    public interface IViewOutStandingOrderUserCase
    {
        IEnumerable<Order> Execute();
    }
}
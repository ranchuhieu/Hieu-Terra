using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.UseCase.AdminPortal.OutStandingOrderScreen
{
    public class ViewOutStandingOrderUserCase : IViewOutStandingOrderUserCase
    {
        private readonly IOrderRespository _orderRespository;
        public ViewOutStandingOrderUserCase(IOrderRespository orderRespository)
        {
            this._orderRespository = orderRespository;
        }
        public IEnumerable<Order> Execute()
        {
            return _orderRespository.GetOutstandingOrders();
        }
    }
}

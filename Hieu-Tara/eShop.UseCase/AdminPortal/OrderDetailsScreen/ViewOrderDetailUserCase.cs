using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.UseCase.AdminPortal.OrderDetailsScreen.interfaces;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.UseCase.AdminPortal.OrderDetailsScreen  
{
    public class ViewOrderDetailUserCase : IViewOrderDetailUserCase
    {
        private readonly IOrderRespository _orderRespository;
        public ViewOrderDetailUserCase(IOrderRespository orderRespository)
        {
            this._orderRespository = orderRespository;
        }
        public Order Execute(int orderId)
        {

            return _orderRespository.GetOrder(orderId);
        }
    }
}

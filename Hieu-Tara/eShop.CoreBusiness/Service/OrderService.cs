using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.CoreBusiness.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.CoreBusiness.Service
{
    //Kiểm tra đơn hàng Validation
    //Mục đích tạo ra Extrac interface dependencies
    public class OrderService : IOrderService
    {
        public bool ValidateCustomerInfomation(string name, string address, string city, string provice, string country)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(provice) || string.IsNullOrWhiteSpace(country))
            {
                return false;
            }
            return true;
        }
        public bool ValidateCreateOrder(Order order)
        {
            //Kiểm tra order 
            if (order == null)
                return false;
            //Kiểm tra đơn hàng có sản phẩm ?
            if (order.LineItems == null || order.LineItems.Count <= 0) return false;

            //Kiểm tra sản phẩm ?
            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 || item.Price < 0 || item.Quantity < 0)
                    return false;
            }
            //Kiểm tra CustomerInfo?
            if (!ValidateCustomerInfomation(order.CustomerName,
                order.CustomerAddress, order.CustomerCity, order.CustomerStateProvince,
                order.CustomerCountry)) return false;
            return true;
        }
        public bool ValidateUpdateOrder(Order order)
        {
            if (order == null) return false;
            if (!order.OrderId.HasValue) return false;
            //Kiểm tra đơn hàng có sản phẩm?
            if (order.LineItems == null || order.LineItems.Count <= 0) return false;
            //Kiểm tra ngay đặt hàng?
            if (!order.DatePlaced.HasValue) return false;

            return true;
        }
        public bool ValidateProcessOrder(Order order)
        {
            //Kiểm tra ngày giao hàng?
            //Đơn hàng có được xử lý bởi Admin User?
            if (!order.DateProcessed.HasValue || string.IsNullOrWhiteSpace(order.AdminUser))
                return false;
            return true;
        }
    }
}

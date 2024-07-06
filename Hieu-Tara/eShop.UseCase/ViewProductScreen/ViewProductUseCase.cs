using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;
using BanHangHieuTerraum.UseCase.ViewProductScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.UseCase.ViewProductScreen
{

    //Trả về 1 sản phẩm
    public class ViewProductUseCase : IViewProductUseCase
    {
        //Khởi tạo biến nội bộ
        public readonly IProductRepository _productRepository;
        //Contructor
        public ViewProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        //Trả về 1 sản phẩm
        public Product Execute(int id)
        {
            return _productRepository.GetProductById(id);
        }
    }

}

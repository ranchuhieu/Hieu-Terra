using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.DataStore.HardCodes.Helper;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.DataStore.SQL.Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            this._dataAccess= dataAccess;
        }
        public IEnumerable<Product> GetProduct(string filter)
        {
            List<Product> list;
            if (string.IsNullOrWhiteSpace(filter))
            {
                list = _dataAccess.Query<Product, dynamic>("select * from Product", new { });
            }
            else
            {
                list = _dataAccess.Query<Product, dynamic>("select * from Product where Name like '%' + @Filter + '%'", new { Filter = filter });
            }

            return list.AsEnumerable();
        }

        public Product GetProductById(int id)
        {
            return _dataAccess.QuerySingle<Product, dynamic>("select * from Product where Id = @Id", new { Id = id });
        }
    }
}

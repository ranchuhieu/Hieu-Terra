// See https://aka.ms/new-console-template for more information
using Dapper;
using DemDapper;
using BanHangHieuTerraum.CoreBusiness.Model;
using System.Data;
using System.Data.SqlClient;

//CRUD =>Create, Read, Update, Delete


var connectStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=eShop;Integrated Security=True;";

var da = new DataAccess(connectStr);

var result1 = da.Query<Product, dynamic>("select * from product", new { });
var result2 = da.QuerySingle<Product, dynamic>("select * from product where Id=@Id", new { Id = 379 });
//using (IDbConnection conn=new SqlConnection(connectStr))
{
    //Get reults console
    //   var results = conn.Query<Product>("select * from product");
	//foreach (var item in results)
	//{
	//	Console.WriteLine($"{item.Name}: {item.Price}");
	//}
    //Insert
    #region
    //var sql = @"insert into product (Id, Brand, Name, Price)
    //			values(@Id,@Brand,@Name,@Price)";
    //var prod = new Product { Id = 1002, Brand = "His Brand", Name = "His Product", Price = 25.5 };
    #endregion

    //Update
    #region
    //var sql = @"update product set Imagelink = @Url " +
    //	" where Name=@Name";
    //var prod = new  { Url = "http://google.com/images", Name = "His product" };

    #endregion
    //Delete

    #region
    //var sql = @"delete from product where Name=@Name";
    //var prod = new { Name = "His product" };
    #endregion
    //Thực thi

    //conn.Execute(sql, prod);


}    
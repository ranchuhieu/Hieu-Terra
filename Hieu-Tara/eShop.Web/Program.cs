using BanHangHieuTerraum.CoreBusiness.Service;
using BanHangHieuTerraum.CoreBusiness.Service.Interfaces;
using BanHangHieuTerraum.DataStore.HardCodes.Helper;

//using eShop.DataStore.HardCode;
using BanHangHieuTerraum.DataStore.SQL.Dapper;
using BanHangHieuTerraum.ShopingCart.LocalStorage;
using BanHangHieuTerraum.StateStore.DI;
using BanHangHieuTerraum.UseCase.AdminPortal.OrderDetailsScreen;
using BanHangHieuTerraum.UseCase.AdminPortal.OrderDetailsScreen.interfaces;
using BanHangHieuTerraum.UseCase.AdminPortal.OrderDetailsScreen.interfaces;
using BanHangHieuTerraum.UseCase.AdminPortal.OutStandingOrderScreen;
using BanHangHieuTerraum.UseCase.AdminPortal.ProcessedOrderScreen;
using BanHangHieuTerraum.UseCase.OrderConfirmScreen;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;
using BanHangHieuTerraum.UseCase.PluginInterface.StateStore;
using BanHangHieuTerraum.UseCase.PluginInterface.UI;
using BanHangHieuTerraum.UseCase.SearchProductScreen;
using BanHangHieuTerraum.UseCase.ShoppingCartScreen;
using BanHangHieuTerraum.UseCase.ShoppingCartScreen.Interfaces;
using BanHangHieuTerraum.UseCase.ViewProductScreen;
using BanHangHieuTerraum.UseCase.ViewProductScreen.Interfaces;
using BanHangHieuTerraum.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

//Add services for auth
builder.Services.AddControllers();
builder.Services.AddAuthentication("eShop.CookieAuth").AddCookie("eShop.CookieAuth", config =>
{
    config.Cookie.Name = "eShop.CookieAuth";
    config.LoginPath = "/authenticate";
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//tồn tại trong dự án chuyển sang AddTransient từ AddSingleton
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IOrderRespository, OrderRepository>();
builder.Services.AddTransient<IDataAccess>(sp=>new DataAccess(builder.Configuration.GetConnectionString("Default")));
//chỉ 1 user view cart
builder.Services.AddScoped<IShopingCart, ShopingCart>();
builder.Services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();

//gọi 1 lần
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
builder.Services.AddTransient<IAddProductToCartUserCase, AddProductToCartUserCase>();
builder.Services.AddTransient<IViewShoppingCartUserCase,ViewShoppingCartUserCase>();
builder.Services.AddTransient<IDeleteProductUserCase, DeleteProductUserCase>();
builder.Services.AddTransient<IUpdateQuantityUserCase, UpdateQuantityUserCase>();
builder.Services.AddTransient<IPlaceOrderUserCase, PlaceOrderUserCase>();
builder.Services.AddTransient<IViewOrderConfrimUserCase, ViewOrderConfrimUserCase>();

builder.Services.AddTransient<IViewOutStandingOrderUserCase,ViewOutStandingOrderUserCase>();
builder.Services.AddTransient<IViewOrderDetailUserCase, ViewOrderDetailUserCase>();
builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
builder.Services.AddTransient<IViewPrcessedOrderUserCase, ViewPrcessedOrderUserCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// xác thực & phân quyền
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

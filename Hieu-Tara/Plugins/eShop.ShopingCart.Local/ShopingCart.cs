using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;
using BanHangHieuTerraum.UseCase.PluginInterface.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BanHangHieuTerraum.ShopingCart.LocalStorage
{
    public class ShopingCart : IShopingCart
    {
        //khai báo
        private readonly IJSRuntime _runtime;
        private const string cstrShoppingCart = "eShop.ShopingCart";
        private readonly IProductRepository _productRepository;

        //khởi tạo contructor
        public ShopingCart(IJSRuntime jSRuntime,IProductRepository productRepository)
        {
            this._runtime = jSRuntime;
            this._productRepository = productRepository;
        }
        public async Task<Order> AddProductAsync(Product product)
        {
            // throw new NotImplementedException();
            var order = await GetOrder();

            //mặc định số lượng là 1
            order.AddProduct(product.Id,1,product.Price);

            await SetOrder(order);
            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            // throw new NotImplementedException();
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);
            return order;
        }

        public Task EmptyAsync()
        {
            //throw new NotImplementedException();
            return this.SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            //throw new NotImplementedException();
            return await GetOrder();
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
           // throw new NotImplementedException();
           await this.SetOrder(order);
            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quatity)
        {
            //throw new NotImplementedException();
            var order=await GetOrder();
            if (quatity < 0)
                return order;
            else if( quatity==0)
                return await DeleteProductAsync(productId);

            var lineItem=order.LineItems.SingleOrDefault(x=>x.ProductId==productId);

            if(lineItem!=null)
                lineItem.Quantity = quatity;

            await SetOrder(order);
            return order;
        }
        //getter, setter
        private async Task<Order> GetOrder()
        {
            Order order = null;
            var strOrder = await _runtime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);

            //so sánh với giá trị tại máy khách local Storage 
            if (!string.IsNullOrEmpty(strOrder) && strOrder.ToLower() != "null")
            {
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            }
            else
            {
                order = new Order();
                SetOrder(order);
            }

            foreach (var item in order.LineItems)
            {
                item.Product = _productRepository.GetProductById(item.ProductId);
            }
            return order;
        }

        private async Task SetOrder(Order order)
        {
            //  throw new NotImplementedException();
            await _runtime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}

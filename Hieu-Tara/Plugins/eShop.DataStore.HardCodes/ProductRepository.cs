using BanHangHieuTerraum.CoreBusiness.Model;
using BanHangHieuTerraum.UseCase.PluginInterface.DataStore;

namespace BanHangHieuTerraum.DataStore.HardCode
{
    //Kế thừa
    public class ProductRepository:IProductRepository
    {
        //Khởi tạo biến cục bộ
        private List<Product> _products;
        //Contructor
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product { Id = 495, Brand = "maybelline", Name = "Maybelline Face Studio Master Hi-Light Light Booster Bronzer", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/991799d3e70b8856686979f8ff6dcfe0_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 488, Brand = "maybelline", Name = "Maybelline Fit Me Bronzer", Price = 10.29, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/d4f7d82b4858c622bb3c1cef07b9d850_ra,w158,h184_pa,w158,h184.png",},
                new Product { Id = 477, Brand = "maybelline", Name = "Maybelline Facestudio Master Contour Kit", Price = 15.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/4f731de249cbd4cb819ea7f5f4cfb5c3_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 468, Brand = "maybelline", Name = "Maybelline Face Studio Master Hi-Light Light Booster Blush", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/4621032a92cb428ad640c105b944b39c_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 439, Brand = "maybelline", Name = "Maybelline Fit Me Blush", Price = 10.29, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/53d5f825461117c0d96946e1029510b0_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 414, Brand = "maybelline", Name = "Maybelline Dream Bouncy Blush", Price = 11.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/51eacb9efebbaee39399e65ffe3d9416_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 380, Brand = "maybelline", Name = "Maybelline Fit Me Shine-Free Foundation Stick", Price = 10.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/d04e7c2ed65dabe1dca4eed9aa268e95_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 379, Brand = "maybelline", Name = "Maybelline Dream Matte Mousse Foundation", Price = 14.79, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/029889b345c76a70e8bb978b73ed1a87_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 366, Brand = "maybelline", Name = "Maybelline Mineral Power Natural Perfecting Powder Foundation", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/c77ad2da76259cfd67a9a9432f635bfb_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 354, Brand = "maybelline", Name = "Maybelline Dream Velvet Foundation", Price = 18.49, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/24517c6c81c92eda31cd32b6327c1298_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 353, Brand = "maybelline", Name = "Maybelline Superstay Better Skin Foundation", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/c7d967ef502ecd79ab7ab466c4952d82_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 339, Brand = "maybelline", Name = "Maybelline Dream Wonder Liquid Touch Foundation", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/ccb99ad6ac7f31a2a73454bdbda01d99_ra,w158,h184_pa,w158,h184.jpeg"},
                new Product { Id = 321, Brand = "maybelline", Name = "Maybelline Dream Liquid Mousse", Price = 14.79, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/1ca6a4a442b9aa6b5f3d94da77d8846c_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 320, Brand = "maybelline", Name = "Maybelline FIT ME! Matte + Poreless Foundation", Price = 10.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/257993e12625cc45a72ec03636ffa5c5_ra,w158,h184_pa,w158,h184.jpg"},
                new Product { Id = 317, Brand = "maybelline", Name = "Maybelline Fit Me Foundation with SPF", Price = 10.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/eccb88d484b8c929fd349b0995a5dba2_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 309, Brand = "maybelline", Name = "Maybelline Expert Wear Eye Shadow Quad", Price = 8.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/c924006882e8e313d445a3a5394e4729_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 307, Brand = "maybelline", Name = "Maybelline Eyestudio Color Tattoo Concentrated Crayon", Price = 10.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/3f9f894b56e0616e44c5ee01dea45217_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 295, Brand = "maybelline", Name = "Maybelline The Nudes Eye Shadow Palette", Price = 17.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/201350fd3e173307ade44520dc87d8fb_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 291, Brand = "maybelline", Name = "Maybelline Eye Studio Color Tattoo 24HR Cream Gel Shadow Leather", Price = 8.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/cf21d194ab14ee3c527d02682c358a7a_ra,w158,h184_pa,w158,h184.png"},
                new Product { Id = 286, Brand = "maybelline", Name = "Maybelline The Nudes Eyeshadow Palette in The Blushed Nudes", Price = 17.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/49d98e112e77d2a9a0c8fad28df89a1e_ra,w158,h184_pa,w158,h184.png"}
            };
        }

        public IEnumerable<Product> GetProduct(string filter =null)
        {
            // throw new NotImplementedException();
            if (string.IsNullOrWhiteSpace(filter))
                return _products;
            return _products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }

        public Product GetProductById(int id)
        {
            //throw new NotImplementedException();
            return _products.FirstOrDefault(x => x.Id == id);
        }

    }
}

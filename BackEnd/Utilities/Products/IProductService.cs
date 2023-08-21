using Microsoft.AspNetCore.Identity;

namespace HeatMaps.Utilities.Products
{
    public interface IProductService
    {
        public Task<List<Product>> GetAll();
        public Task<Product> Get(int id);
        public Task<Product> Get(string ProductId);
        public void Update(int id, Product newProductDetails);
        public void Delete(int id);
        public void Add(Product product);
    }
}

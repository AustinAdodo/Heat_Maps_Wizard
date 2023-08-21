using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HeatMaps.Utilities.Products
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _productsContext;
        public ProductService(ApplicationDbContext productsContext)
        {
            _productsContext = productsContext;
        }
        async Task<Product> IProductService.Get(int id)
        {
            var Product = await _productsContext.Products.FindAsync(id);
            if (Product != null) return Product;
            var result = Enumerable.Empty<Product>().ToList().First();
            return result;
        }

        async Task<Product> IProductService.Get(string ProductId)
        {
            var Product = await _productsContext.Products.Where(a => a.ProductId == ProductId).FirstAsync();
            if (Product != null) return Product;
            var result = Enumerable.Empty<Product>().ToList().First();
            return result;
        }

        public async Task<List<Product>> GetAll()
        {
            var Products = await _productsContext.Products.ToListAsync();
            if (Products != null) return Products;
            var result = Enumerable.Empty<Product>().ToList();
            return result;
        }

        async void IProductService.Update(int id, Product newProductDetails)
        {
            var result = await _productsContext.Products.FindAsync(id);
            if (result != null)
            {
                foreach (PropertyInfo prty in typeof(Product).GetProperties())
                {
                    prty.SetValue(result, prty.GetValue(newProductDetails));
                }
                _productsContext.Products.Attach(result);
                _productsContext.Entry(result).State = EntityState.Modified;
            }
            await _productsContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

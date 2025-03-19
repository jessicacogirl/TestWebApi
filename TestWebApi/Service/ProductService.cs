using TestWebApi.Domains.Model;
using TestWebApi.Domains.Repositories;

namespace TestWebApi.Service
{
    public class ProductService :IProductService
    {
        private readonly IProductRepositories _productRepositories;
        public ProductService(IProductRepositories productRepositories)
        {
            _productRepositories = productRepositories;
        }

        public Task<Guid?> Add(Product product)
        {
            return _productRepositories.Add(product);
        }

        public async Task<int> Delete(Guid id)
        {
            return await _productRepositories.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepositories.GetAllProducts();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _productRepositories.GetProductById(id);
        }

        public async Task<int> Update(Product product)
        {
            return await _productRepositories.Update(product);
        }
    }
}

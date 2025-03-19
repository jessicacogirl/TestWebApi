using TestWebApi.Domains.Model;

namespace TestWebApi.Domains.Repositories
{
    public interface IProductRepositories
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(Guid id);
        Task<Guid?> Add(Product product);
        Task<int> Update(Product product);
        Task<int> Delete(Guid id);

    }
}

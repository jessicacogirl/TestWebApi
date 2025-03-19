using System.Data.SqlClient;
using TestWebApi.Domains.Model;
using Dapper;

namespace TestWebApi.Domains.Repositories
{
    public class ProductRepositories : IProductRepositories
    {
        private readonly string _connectionString;

        public ProductRepositories(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Guid?> Add(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                product.Id = Guid.NewGuid();
                var query = @"INSERT INTO Products
                                (Id, ProductName, UnitPrice, Quantity)
                              VALUES
                                (@Id, @ProductName, @UnitPrice, @Quantity)";

                var result = await connection.ExecuteAsync(query, new
                {
                    product.Id,
                    product.ProductName,
                    product.UnitPrice,
                    product.Quantity
                });

                return product.Id;

            }
        }

        public async Task<int> Delete(Guid productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"DELETE Products WHERE Id = @ProductId";
                return await connection.ExecuteAsync(query, new { ProductId = productId });
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT
                                    Id, 
                                    ProductName,
                                    UnitPrice,
                                    Quantity
                                  From Products WITH(NOLOCK)";
                return await connection.QueryAsync<Product>(query);
            }
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT
                                    Id,
                                    ProductName,
                                    UnitPrice,
                                    Quantity
                                  FROM Products WITH(NOLOCK)
                                  WHERE Id = @ProductId";
                return await connection.QueryFirstAsync<Product>(query);
            }
        }

        public async Task<int> Update(Product product)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    product.Id = Guid.NewGuid();
                    var query = @"UPDATE Products 
                                  SET ProductName = @ProductName, UnitPrice =  @UnitPrict, Quantity = @Quantity
                                  WHERE Id = @Id";
                    return await connection.ExecuteAsync(query, new 
                    {
                        product.Id,
                        product.ProductName,
                        product.UnitPrice,
                        product.Quantity
                    });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

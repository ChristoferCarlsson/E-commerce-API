using WebApplication5.Models;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync(string? name, string? sort, int page, int pageSize);
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> ProductExistsAsync(int id);
}

using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class ProductService : IProductService
    {
        private readonly EcommerceDbContext _context;

        public ProductService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync(string? name, string? sort, int page, int pageSize)
        {
            var query = _context.Products.AsQueryable();

            // Apply filtering by product name if a filter is passed
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.ToLower() == "asc")
                {
                    query = query.OrderBy(p => p.Price);
                }
                else if (sort.ToLower() == "desc")
                {
                    query = query.OrderByDescending(p => p.Price);
                }
            }

            // Pagination logic
            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ProductExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }
    }
}

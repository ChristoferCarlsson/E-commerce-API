namespace WebApplication5.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
    }
}
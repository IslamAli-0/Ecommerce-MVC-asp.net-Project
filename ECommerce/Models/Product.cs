namespace ECommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string? Img { get; set; }
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public List<OrderItem>? OrderItems { get; set; } = new();
    }
}

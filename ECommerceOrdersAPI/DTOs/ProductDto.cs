namespace ECommerceOrdersAPI.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}

namespace OrderManager.Core.Models.DTOs
{
    public class OrderCreateDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

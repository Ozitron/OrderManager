namespace OrderManager.Core.Models.DTOs
{
    public class OrderGetDto
    {
        public OrderGetDto()
        {
            ProductTypes = new List<ProductGetDto>();
        }

        public decimal RequiredBinWidth { get; set; }

        public ICollection<ProductGetDto> ProductTypes { get; set; }
    }
}

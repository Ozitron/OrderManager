namespace OrderManager.Core.Models
{
    public class OrderGetDto
    {
        public OrderGetDto(double requiredBinWidth, ICollection<ProductGetModel> productTypes)
        {
            RequiredBinWidth = requiredBinWidth;
            ProductTypes = productTypes;
        }

        public double RequiredBinWidth { get; set; }

        public ICollection<ProductGetModel> ProductTypes { get; set; }
    }
}

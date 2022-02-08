using System.ComponentModel.DataAnnotations;

namespace OrderManager.Core.Entities
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OrderManager.Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
    }
}

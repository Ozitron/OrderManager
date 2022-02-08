using System.ComponentModel.DataAnnotations;

namespace OrderManager.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public decimal Width { get; set; }
    }
}

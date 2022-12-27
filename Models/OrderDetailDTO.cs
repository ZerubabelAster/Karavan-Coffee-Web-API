using KaravanCoffeeWebAPI.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateOrderDetailDTO
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        public string ExtrasRequested { get; set; }
        public string RemovalRequested { get; set; }

        [Required]
        public double SubTotal { get; set; }

        public double? Rating { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
    }

    public class UpdateOrderDetailDTO : CreateOrderDetailDTO
    {

    }

    public class OrderDetailDTO : CreateOrderDetailDTO
    {
        public int OrderDetailId { get; set; }

        public OrderDTO Order { get; set; }
        public ProductDTO Product { get; set; }

    }
}

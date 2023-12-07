using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agraja.Domain.Models
{
    public class BoxxProduct
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey("BoxId")]
        public int BoxId { get; set; }
        public Box? Box { get; set; }

    }
}

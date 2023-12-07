using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agraja.Domain.Models
{
    public class AgroxProduct
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey("AgroId")]
        public int AgroId { get; set; }
        public Agro? Agro { get; set; }

    }
}

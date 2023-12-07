using System.ComponentModel.DataAnnotations;

namespace Agraja.Domain.Models
{

    public class Product
    {
        // Inicialización en el constructor propiedades para que no sean nulas.
        public Product() 
        {
            Name = string.Empty;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

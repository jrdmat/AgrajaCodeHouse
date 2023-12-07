using System.ComponentModel.DataAnnotations;

namespace Agraja.Domain.Models
{

    public class Box
    {
        // Inicialización en el constructor propiedades para que no sean nulas.
        public Box() 
        {
            Name = string.Empty;
            Description = string.Empty;
            Picture = string.Empty;
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Kg { get; set; }

        [Required]
        public double Prize { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string Picture { get; set; }
    }
}

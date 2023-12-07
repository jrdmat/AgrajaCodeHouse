using System.ComponentModel.DataAnnotations;

namespace Agraja.Domain.Models
{

    public class Agro
    {
        public Agro()
        {
            Name = string.Empty;
            Description = string.Empty;
            Province = string.Empty;
            Picture = string.Empty;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public double Prize { get; set; }
        
        [Required]
        public string Picture { get; set; }
    }
}

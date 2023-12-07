using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraja.Domain.Models
{
    public class PaymentType
    {
        public PaymentType()
        {
            // Inicialización en el constructor propiedades para que no sean nulas.
            Name = string.Empty; 
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Agraja.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }
    }
}

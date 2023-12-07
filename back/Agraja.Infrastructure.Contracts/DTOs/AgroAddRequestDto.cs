using Agraja.Domain.Models;

namespace Agraja.Infrastructure.Contracts.DTOs
{
    public class AgroAddRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Province { get; set; }
        public double Prize { get; set; }
        public string Picture { get; set; }
        public List<int> ProductIds { get; set; }

    }
}

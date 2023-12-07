using Agraja.Domain.Models;

namespace Agraja.Infrastructure.Contracts.DTOs
{
    public class BoxAddRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Kg { get; set; }
        public double Prize { get; set; }
        public int Stock { get; set; }
        public string Picture { get; set; }
        public List<int> ProductIds { get; set; }

    }
}

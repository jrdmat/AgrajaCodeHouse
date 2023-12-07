using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraja.Infrastructure.Contracts.DTOs
{
    public class BoxUpdateRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

    }
}

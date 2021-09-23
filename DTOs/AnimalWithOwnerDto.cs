using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinaryClinic.DTOs
{
    public class AnimalWithOwnerDto
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace VeterinaryClinic.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Vaccinations = new HashSet<Vaccination>();
        }

        public int AnimalId { get; set; }
        public string Name { get; set; }
        public int? OwnerId { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual ICollection<Vaccination> Vaccinations { get; set; }
    }
}

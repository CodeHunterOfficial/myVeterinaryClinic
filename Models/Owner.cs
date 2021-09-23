using System;
using System.Collections.Generic;

#nullable disable

namespace VeterinaryClinic.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Animals = new HashSet<Animal>();
        }

        public int OwnerId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}

using myVeterinaryClinic.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace VeterinaryClinic.Models
{
    public partial class Service
    {
        public Service()
        {
            DocServs = new HashSet<DocServ>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

       public virtual ICollection<DocServ> DocServs { get; set; }
    }
}

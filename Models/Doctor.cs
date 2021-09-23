using myVeterinaryClinic.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace VeterinaryClinic.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            DocServs = new HashSet<DocServ>();
            Vaccinations = new HashSet<Vaccination>();
        }

        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }      
        public virtual ICollection<Vaccination> Vaccinations { get; set; }
        public virtual ICollection<DocServ> DocServs { get; set; }
    }
}

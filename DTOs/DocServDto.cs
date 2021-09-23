using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myVeterinaryClinic.DTOs
{
    public class DocServDto
    {
        public int DocServID { get; set; }
        public int doctorID { get; set; }
        public int serviceID { get; set; }
    }
}

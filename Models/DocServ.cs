using VeterinaryClinic.Models;

namespace myVeterinaryClinic.Models
{
    public class DocServ
    {
        public int DocServID { get; set; }
        public int doctorID { get; set; }
        public int serviceID { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Service Service { get; set; }

    }
}

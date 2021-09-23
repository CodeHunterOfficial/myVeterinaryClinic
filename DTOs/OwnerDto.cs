using System;
using System.Threading.Tasks;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.DTOs
{
    public class OwnerDto
    {        
        public int OwnerId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }      
    }
}

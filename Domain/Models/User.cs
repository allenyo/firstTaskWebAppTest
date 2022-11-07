using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User
    {
    
        public int Id { get; set; }
    
        public string FirstName { get; set; } = string.Empty;
  
        public string LastName { get; set; } = string.Empty;
 
        public string Email { get; set; } = string.Empty;
   
        public string Phone { get; set; } = string.Empty;

        public string BirthYear { get; set; } = string.Empty;

        public string BirthMonth { get; set; } = string.Empty;
    
        public string BirthDay { get; set; } = string.Empty;

        public DateTime Time { get; set; }

    }
}

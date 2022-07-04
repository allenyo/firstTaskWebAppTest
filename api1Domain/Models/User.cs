namespace api1Domain.Models
{
    public class User
    {

        public int Id { get; set; } 
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string BirthDay { get; set; } = string.Empty;
        public DateTime Time { get; set; }
    }
}

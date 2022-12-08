namespace api1Domain.Models
{
    public class ErrorModel
    {
        public string Error { get; set; } = "Unknown";
        public string Message { get; set; } = "Unknown error thrown";
        public uint Code { get; set; }

        public override string ToString()
        {
            return "Error - " + Error  + "\n" + "Message - " + Message + "\n"  + "(" + "code - " + Code + ")";  
        }
    }


 
}

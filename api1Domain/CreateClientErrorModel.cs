namespace Models
{

    public class CreateClientResponseModel : CreateClientErrorModel
    {
        public string? Data { get; set; }
    }
    public class CreateClientErrorModel
    {
        public int? Error { get; set; }
        public string? ErrorDescription { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }
    }
}
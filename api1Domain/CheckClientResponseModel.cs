namespace Models
{
    public class CheckClientResponseModel : CreateClientErrorModel
    {
        public CheckClientData? Data { get; set; }
    }

    public class CheckClientData
    {
        public string? ClientCode { get; set; }
        public string? Isn { get; set; }
    }
}

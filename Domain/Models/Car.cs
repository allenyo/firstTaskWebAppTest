namespace Domain.Models
{
    public partial class Car
    {
        public long Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public long Year { get; set; }
        public string? BoostType { get; set; }
        public string EngineType { get; set; } = null!;
        public string GearboxType { get; set; } = null!;
    }
}

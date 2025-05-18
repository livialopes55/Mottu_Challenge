namespace MottuTrackerAPI.Models
{
    public class Localizacao
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataHora { get; set; }
        public int MotoId { get; set; }
        public Moto? Moto { get; set; }
    }
}
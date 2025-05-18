namespace MottuTrackerAPI.Models
{
    public class Moto
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string DispositivoId { get; set; }
        public List<Localizacao>? Localizacoes { get; set; }
    }
}
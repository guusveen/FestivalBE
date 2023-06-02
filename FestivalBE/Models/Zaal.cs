namespace FestivalBE.Models
{
    public class Zaal
    {
        public int? Id { get; set; }
        public string? Naam { get; set; }
        public int? Capaciteit { get; set; }
        public int? LocatieId { get; set; }
        public Locatie? Locatie { get; set; }
        public ICollection<Voorstelling>? Voorstellingen { get; set; }
    }
}

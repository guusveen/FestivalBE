namespace FestivalBE.Models
{
    public class Locatie
    {
        public int? Id { get; set; }
        public string? Adres { get; set; }
        public ICollection<Zaal>? Zalen { get; set; }
        public ICollection<Festival>? Festivals { get; set; }

    }

}

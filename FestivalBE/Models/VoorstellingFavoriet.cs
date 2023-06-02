namespace FestivalBE.Models
{
    public class VoorstellingFavoriet
    {
        public int? Id { get; set; }
        public int? BezoekerId { get; set; }
        public Bezoeker? Bezoeker { get; set; }
        public int? VoorstellingId { get; set; }
        public Voorstelling? Voorstelling { get; set; }
    }

}

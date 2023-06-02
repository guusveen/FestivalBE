namespace FestivalBE.Models
{
    public class ArtiestFavoriet
    {
        public int? Id { get; set; }
        public int? BezoekerId { get; set; }
        public Bezoeker? Bezoeker { get; set; }
        public int? ArtiestId { get; set; }
        public Artiest? Artiest { get; set; }
    }
}

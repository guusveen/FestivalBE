using System.Net.Sockets;

namespace FestivalBE.Models
{
    public class Bezoeker
    {
        public int? Id { get; set; }
        public string? Naam { get; set; }
        public string? Adres { get; set; }
        public DateTime? Geboortedatum { get; set; }
        public string? Email { get; set; }
        public ICollection<VoorstellingFavoriet>? VoorstellingFavorieten { get; set; }
        public ICollection<ArtiestFavoriet>? ArtiestFavorieten { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
    }

}

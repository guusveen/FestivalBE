namespace FestivalBE.Models
{
    public class Organisator
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        // Navigation properties
        public virtual ICollection<Festival>? Festivals { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FestivalBE.Models
{
    public class Organisator
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        // Navigation properties
        public virtual ICollection<Festival>? Festivals { get; set; }
    }
}

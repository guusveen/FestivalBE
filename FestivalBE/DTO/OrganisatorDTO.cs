using FestivalBE.Models;
using System.ComponentModel.DataAnnotations;

namespace FestivalBE.DTO
{
    public class OrganisatorDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        // Navigation properties
        public virtual ICollection<Festival>? Festivals { get; set; }
    }
}

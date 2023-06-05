﻿using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace FestivalBE.Models
{
    public class Bezoeker
    {
        public int? Id { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
       
        [Required]
        public string? Password { get; set; }
        public string? Naam { get; set; }
        public string? Adres { get; set; }
        public DateTime? Geboortedatum { get; set; }
        public virtual ICollection<VoorstellingFavoriet>? VoorstellingFavorieten { get; set; }
        public virtual ICollection<ArtiestFavoriet>? ArtiestFavorieten { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }
    }

}

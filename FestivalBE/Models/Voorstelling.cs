﻿namespace FestivalBE.Models
{
    public class Voorstelling
    {
        public int? Id { get; set; }
        public string? Naam { get; set; }
        public string? Beschrijving { get; set; }
        public string? Afbeelding { get; set; }
        public DateTime? StartTijd { get; set; }
        public DateTime? EindTijd { get; set; }
        public int? ZaalId { get; set; }
        public Zaal? Zaal { get; set; }
        public int? ArtiestId { get; set; }
        public Artiest? Artiest { get; set; }
        public int? FestivalId { get; set; }
        public Festival? Festival { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
    }
}
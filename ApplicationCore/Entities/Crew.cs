using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Crew
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(128)]
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? TmdbUrl { get; set; }
        [MaxLength(2084)]
        public string? ProfilePath { get; set; }

        // navigation property:
        public ICollection<MovieCrew>? Movies { get; set; }

    }
}

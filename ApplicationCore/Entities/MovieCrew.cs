using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class MovieCrew
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int CrewId { get; set; }
        [Required, MaxLength(128)]
        public string Department { get; set; }
        [Required, MaxLength(128)]
        public string Job { get; set; }

        // navigation property 
        public Movie Movie { get; set; }
        public Crew Crew { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class MovieGenre
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int GenreId { get; set; }

        public Movie Movie { get; set; }
        public Genre Genre { get; set; }

    }
}

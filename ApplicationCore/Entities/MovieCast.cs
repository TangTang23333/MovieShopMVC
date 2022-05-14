using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("MovieCast")]
    public class MovieCast
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int CastId { get; set; }

        [Required, MaxLength(450)]
        public string Character { get; set; }

        //

        public Movie Movie { get; set; }
        public Cast Cast { get; set; }



    }
}

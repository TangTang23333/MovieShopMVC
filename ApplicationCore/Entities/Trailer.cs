using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        [Required]
        public int Id { get; set; }
        // foreign Key, 
        [Required]
        public int MovieId { get; set; }

        [MaxLength(2084)]
        public string? TrailerURL { get; set; }

        [MaxLength(2084)]
        public string? Name { get; set; }
        // establish connection to Movie table
        // navigation property

        public Movie Movie { get; set; }


    }
}

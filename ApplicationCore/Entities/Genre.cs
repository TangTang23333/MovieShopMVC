// use fluent API
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }

        public List<MovieGenre> Movies { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Review
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required, Column(TypeName = "decimal(3,2)")]
        public decimal Rating { get; set; }

        public string? ReviewText { get; set; }


        //

        public Movie Movie { get; set; }
        public User User { get; set; }

    }
}

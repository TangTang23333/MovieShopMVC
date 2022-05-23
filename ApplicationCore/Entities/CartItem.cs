using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class CartItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }

        // navigation property 
        public Movie Movie { get; set; }
        public User User { get; set; }

    }
}


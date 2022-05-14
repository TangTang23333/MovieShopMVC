using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Purchase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public Guid PurchaseNumber { get; set; }


        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPrice { get; set; }


        [Required, Column(TypeName = "datetime2(7)")]

        public DateTime PurchaseDateTime { get; set; }

        [Required]
        public int MovieId { get; set; }


        //navigation property 
        public Movie Movie { get; set; }
        public User User { get; set; }


    }
}

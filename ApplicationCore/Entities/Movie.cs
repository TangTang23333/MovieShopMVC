using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.Entities
{
    [Table("Movie")]
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string Title { get; set; } // add attribute to make it the PK


        public string? Overview { get; set; }
        [MaxLength(512)]
        public string? Tagline { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Budget { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Revenue { get; set; }
        [MaxLength(2084)]
        public string? ImdbURL { get; set; }
        [MaxLength(2084)]
        public string? TmdbURL { get; set; }
        [MaxLength(2084)]

        public string? PosterURL { get; set; }
        [MaxLength(2084)]
        public string? BackdropURL { get; set; }
        [MaxLength(64)]
        public string? OriginalLanguage { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }







        // one to many relations 
        public ICollection<Trailer> Trailers { get; set; }
        public ICollection<MovieCast> Casts { get; set; }
        public ICollection<MovieGenre> Genres { get; set; }
        public ICollection<MovieCrew> Crews { get; set; }


    }
}

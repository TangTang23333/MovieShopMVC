using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class MovieCreateRequestModel
    {

        public int Id { get; set; }

        [MaxLength(150), MinLength(0), Required]
        public string Title { get; set; }

        public string? ImdbURL { get; set; }
        public string? TmdbURL { get; set; }

        [Required]
        public string PosterURL { get; set; }
        [MaxLength(2084), MinLength(0)]
        public string? Overview { get; set; }

        [MaxLength(2084), MinLength(0)]
        public string? TagLine { get; set; }


        [Required, MaxLength(2084)]
        public string BackdropURL { get; set; }

        public string? OriginalLanguage { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        [Range(0.99, 49, ErrorMessage = "Price has to within range(0.99, 49)")]
        public decimal? Price { get; set; }


        [RegularExpression(@"^(\d{1,18})(.\d{1})?$"), Range(0, 5000000000, ErrorMessage = "Revenue has to be within the range(0, 5000000000)")]
        public decimal? Revenue { get; set; }
        [Range(0, 5000000000, ErrorMessage = "Budget has to be within range(0, 500000000)")]
        public decimal? Budget { get; set; }

        public List<MovieGenreModel> Genres { get; set; }
    }
}

namespace ApplicationCore.Models
{
    public class FavoriteDetailModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int MovieId { get; set; }

        public decimal? Price { get; set; }


        public string? PosterURL { get; set; }

        public string Title { get; set; }

    }
}

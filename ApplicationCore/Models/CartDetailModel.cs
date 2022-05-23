namespace ApplicationCore.Models
{
    public class CartDetailModel
    {

        public int Id { get; set; }

        public int MovieId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }
        public string PosterURL { get; set; }
        public decimal? Price { get; set; }

    }
}

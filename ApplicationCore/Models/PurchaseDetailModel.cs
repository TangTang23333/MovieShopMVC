namespace ApplicationCore.Models
{
    public class PurchaseDetailModel
    {
        public int MovieId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal? PurchasePrice { get; set; }

        public string PurchaseNumber { get; set; }

        public string? PosterURL { get; set; }

        public string Title { get; set; }


    }
}

﻿namespace ApplicationCore.Models
{
    public class MovieDetailByUserModel
    {
        public int? UserId { get; set; }
        public bool? IsFavorite { get; set; }
        public bool? IsPurchased { get; set; }
        public ReviewRequestModel? Review { get; set; }
        public int? FavoriteId { get; set; }
        public int? PurchaseId { get; set; }



        public int Id { get; set; }

        public string Title { get; set; }
        public string? PosterURL { get; set; }
        public string? Overview { get; set; }
        public string? TagLine { get; set; }

        public decimal? Price { get; set; }

        public decimal? AvgRating { get; set; }

        public int? Runtime { get; set; }


        public List<GenreModel>? Genres { get; set; }
        public List<TrailerModel>? Trailers { get; set; }

        public decimal? Revenue { get; set; }
        public decimal? Budget { get; set; }
        public DateTime? ReleaseDate { get; set; }


        public List<CastModel>? Casts { get; set; }

        public List<ReviewRequestModel>? Reviews { get; set; }







    }
}

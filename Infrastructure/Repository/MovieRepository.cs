using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MovieRepository : Repository<Movie>, IMovieRepository

{
    // dapper (ORM)  -> stackoverflow 
    // ado.net , MICROSOFT sql connection ,sqlcommand, 
    // ENTITY FRAMEWORK ==> LINQ 



    private readonly MovieShopDbContext _context;
    public MovieRepository(MovieShopDbContext context) : base(context)
    {
        this._context = context;
    }

    public async Task<List<Movie>> GetAll()
    {
        return await this._context.Set<Movie>().ToListAsync();
    }
    public async Task<List<Movie>> GetTop30GlossingMovies()
    {
        // SQL Database 
        // data access logic
        // ADO.NET (Microsoft) SQLConnection, SQLCommand
        // Dapper (ORM) -> StackOverflow
        // Entity Framework Core => LINQ
        // SELECT top 30 * from Movie order by Revenue
        // movies.orderbydescnding(m=> m.Revenue).Take(30)

        var movies = await this._context.Set<Movie>().OrderByDescending(m => m.Revenue).Take(30).ToListAsync();

        return movies;
    }


    // not authorized 
    public async Task<Movie> GetById(int Id)

    {




        var movie = await this._context.Set<Movie>()
                    .Include(m => m.Genres).ThenInclude(m => m.Genre)
                    .Include(m => m.Casts).ThenInclude(m => m.Cast)
                    .Include(m => m.Trailers)
                    .FirstOrDefaultAsync(m => m.Id == Id);


        return movie;
    }


    public async Task<PageResultSet<Movie>> GetMoviesByGenre(string genre, int pageNumber = 1, int pageSize = 30)
    {


        var genreId = this._context.Set<Genre>().FirstOrDefault(g => g.Name == genre).Id;

        var totalMovieCount = await this._context.Set<MovieGenre>().Where(m => m.GenreId == genreId).CountAsync();

        var movies = await this._context.Set<MovieGenre>()
            .Where(mg => mg.GenreId == genreId)
            .Include(m => m.Movie)
            .OrderByDescending(m => m.Movie.Revenue)
            .Select(mg => new Movie { Id = mg.MovieId, Title = mg.Movie.Title, PosterURL = mg.Movie.PosterURL })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var pageOfMovies = new PageResultSet<Movie>(movies, pageNumber, pageSize, totalMovieCount);

        return pageOfMovies;
    }


    public Task<List<Review>> GetReviews(int Id)
    {
        var reviews = this._context.Set<Review>()
            .Include(r => r.Movie)
            .Where(r => r.MovieId == Id).ToListAsync();


        return reviews;
    }


    public async Task<PageResultSet<MovieDetailsModel>> GetMoviesByReleaseDate(int pageNumber, int pageSize)
    {

        var totalMovieCount = await this._context.Set<Movie>().CountAsync();

        var movies = await this._context.Set<Movie>()
            .OrderByDescending(m => m.ReleaseDate)
            .Select(m => new MovieDetailsModel { Id = m.Id, Title = m.Title, PosterURL = m.PosterURL })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var pageOfMovies = new PageResultSet<MovieDetailsModel>(movies, pageNumber, pageSize, totalMovieCount);

        return pageOfMovies;
    }


    public async Task<List<MovieCardModel>> GetTopRated30()
    {
        var movies = from r in this._context.Set<Review>().Include(r => r.Movie)

                     group r by r.MovieId into mr

                     orderby mr.Average(r => r.Rating) descending
                     select new MovieCardModel
                     {
                         Id = mr.FirstOrDefault().Movie.Id,
                         Title = mr.FirstOrDefault().Movie.Title,
                         PosterURL = mr.FirstOrDefault().Movie.PosterURL
                     };

        return await movies.ToListAsync();




        //Include(r => r.Movie)
        //.GroupBy(r => r.MovieId)
        //.Select(x => new { Id = x.Key,avgRating = x.Average(review => review.Rating) })

        //.OrderByDescending(x => x.avgRating)
        //.Take(30)
        //.ToListAsync();


        var res = new List<MovieDetailsModel>();

        foreach (var m in movies)
        {
            res.Add(new MovieDetailsModel { Id = m.Id, Title = m.Title, PosterURL = m.PosterURL });
        }

    }

    public async Task<PageResultSet<Movie>> GetMoviesByGenreId(int genreId, int pageNumber, int pageSize)
    {
        var totalMovieCount = await this._context.Set<MovieGenre>().Where(m => m.GenreId == genreId).CountAsync();

        var movies = await this._context.Set<MovieGenre>()
            .Where(mg => mg.GenreId == genreId)
            .Include(m => m.Movie)
            .OrderByDescending(m => m.Movie.Revenue)
            .Select(mg => new Movie { Id = mg.MovieId, Title = mg.Movie.Title, PosterURL = mg.Movie.PosterURL })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var pageOfMovies = new PageResultSet<Movie>(movies, pageNumber, pageSize, totalMovieCount);

        return pageOfMovies;
    }


    public async Task<MovieCreateRequestModel> CreateNewMovie(MovieCreateRequestModel model)
    {

        var movie = new Movie
        {
            Title = model.Title,
            BackdropURL = model.BackdropURL,
            Budget = model.Budget,
            Overview = model.Overview,
            Tagline = model.TagLine,
            Revenue = model.Revenue,
            ImdbURL = model.ImdbURL,
            TmdbURL = model.TmdbURL,
            PosterURL = model.PosterURL,
            OriginalLanguage = model.OriginalLanguage,
            ReleaseDate = model.ReleaseDate,
            RunTime = model.RunTime,
            Price = model.Price


        };
        await this._context.Set<Movie>().AddAsync(movie);
        await this._context.SaveChangesAsync();

        var movieCreated = await this._context.Set<Movie>().FirstOrDefaultAsync(M => M.Title == model.Title);
        if (movieCreated == null)
        {
            throw new Exception("Create new movie failed!");
        }
        // call genre to create new movie-genre 
        foreach (var mg in model.Genres)
        {
            var movieGenre = new MovieGenre { GenreId = mg.GenreId, MovieId = mg.MovieId };
            await this._context.Set<MovieGenre>().AddAsync(movieGenre);
            await this._context.SaveChangesAsync();

        }

        model.Id = movieCreated.Id;
        return model;



    }


    public async Task<MovieCreateRequestModel> UpdateMovie(MovieCreateRequestModel model)
    {


        var movie = await this._context.Set<Movie>().FirstOrDefaultAsync(m => m.Id == model.Id);

        if (movie == null)
        {
            throw new Exception("No such movie found, please recheck movie Id!");
        }

        movie.Title = model.Title;
        movie.PosterURL = model.PosterURL;
        movie.Price = model.Price;
        movie.BackdropURL = model.BackdropURL;
        movie.Budget = model.Budget;
        movie.ImdbURL = model.ImdbURL;
        movie.OriginalLanguage = model.OriginalLanguage;
        movie.Overview = model.Overview;
        movie.ReleaseDate = model.ReleaseDate;
        movie.Revenue = model.Revenue;
        movie.RunTime = model.RunTime;
        movie.Tagline = model.TagLine;
        movie.TmdbURL = model.TmdbURL;

        // delete original moviegenre 


        var moviegenres = this._context.Set<MovieGenre>().Where(mg => mg.MovieId == mg.MovieId);
        this._context.Set<MovieGenre>().RemoveRange(moviegenres);
        await this._context.SaveChangesAsync();




        // then update new movie-genre 
        foreach (var mg in model.Genres)
        {
            var movieGenre = new MovieGenre { GenreId = mg.GenreId, MovieId = mg.MovieId };
            await this._context.Set<MovieGenre>().AddAsync(movieGenre);
            await this._context.SaveChangesAsync();

        }


        return model;



    }
}

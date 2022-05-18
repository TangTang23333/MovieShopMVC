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





    public Task<List<Genre>> GetGenreList()
    {
        throw new NotImplementedException();
    }


}

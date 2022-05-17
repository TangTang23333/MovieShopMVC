using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MovieRepository : Repository<Movie>, IMovieRepository

{
    // dapper (ORM)  -> stackoverflow 
    // ado.net , MICROSOFT sql connection ,sqlcommand, 
    // ENTITY FRAMEWORK ==> LINQ 


    public MovieRepository(MovieShopDbContext context) : base(context)
    {

    }


    public List<Movie> GetTop30GlossingMovies()
    {
        // SQL Database 
        // data access logic
        // ADO.NET (Microsoft) SQLConnection, SQLCommand
        // Dapper (ORM) -> StackOverflow
        // Entity Framework Core => LINQ
        // SELECT top 30 * from Movie order by Revenue
        // movies.orderbydescnding(m=> m.Revenue).Take(30)

        var movies = this._context.Set<Movie>().OrderByDescending(m => m.Revenue).Take(30).ToList();

        return movies;
    }



    public Movie GetById(int Id)

    {




        var movie = this._context.Set<Movie>()
                    .Include(m => m.Genres).ThenInclude(m => m.Genre)
                    .Include(m => m.Casts).ThenInclude(m => m.Cast)
                    .Include(m => m.Trailers)
                    .FirstOrDefault(m => m.Id == Id);


        return movie;
    }





    public IEnumerable<Movie> GetAll()
    {
        throw new NotImplementedException();
    }

    public Movie Add(Movie entity)
    {
        throw new NotImplementedException();
    }

    public Movie Update(Movie entity)
    {
        throw new NotImplementedException();
    }

    public Movie Delete(int Id)
    {
        throw new NotImplementedException();
    }
}

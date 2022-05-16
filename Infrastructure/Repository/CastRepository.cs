using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class CastRepository : ICastRepository
    {

        private readonly MovieShopDbContext _context;
        public CastRepository(MovieShopDbContext context)
        {
            this._context = context;
        }


        public Cast GetMovies(int Id)

        {

            // how about using SP to perform optimized query and then call st to perform query?????




            var movies = this._context.Set<MovieCast>().Where(moviecast => moviecast.CastId == Id).ToList();
            var cast = this._context.Set<Cast>().SingleOrDefault(c => c.Id == Id);

            cast.Movies = movies;


            return cast;
        }


        public IQueryable<Cast> GetAll()
        {
            return this._context.Set<Cast>();
        }
    }
}



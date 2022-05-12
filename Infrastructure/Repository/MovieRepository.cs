using ApplicationCore.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        // dapper (ORM)  -> stackoverflow 
        // ado.net , MICROSOFT sql connection ,sqlcommand, 
        // ENTITY FRAMEWORK ==> LINQ 
        public List<Movie> GetTop30GlossingMovies()
        {
            throw new NotImplementedException();
        }
    }
}

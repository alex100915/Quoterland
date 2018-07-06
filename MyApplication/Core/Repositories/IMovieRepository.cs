using System.Collections.Generic;
using MyApplication.Core.Models;

namespace MyApplication.Core.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
    }
}
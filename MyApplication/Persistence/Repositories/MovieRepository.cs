using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;

namespace MyApplication.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IApplicationDbContext _context;

        public MovieRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
    }
}
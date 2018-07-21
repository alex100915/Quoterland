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

        public Movie GetMovieById(int id)
        {
            return _context.Movies.SingleOrDefault(m => m.Id == id);
        }

        public void Remove(Movie movie)
        {
            _context.Movies.Remove(movie);
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
        }
    }
}
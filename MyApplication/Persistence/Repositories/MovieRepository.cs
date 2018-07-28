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

        public IEnumerable<Movie> GetMoviesByGenre(int id)
        {
            return _context.Movies.Where(m => m.ProductionTypeId == 1 && m.Genre.Id == id).ToList();
        }

        public IEnumerable<Movie> GetTvsByGenre(int id)
        {
            return _context.Movies.Where(t => t.ProductionTypeId == 2 && t.GenreId == id).ToList();
        }
    }
}
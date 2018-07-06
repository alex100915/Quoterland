using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;

namespace MyApplication.Persistence.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly ApplicationDbContext _context;

        public QuoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Quote> GetQuotesByMovieTitle(string movie)
        {
            return _context.Quotes
                .Include(q => q.Movie)
                .Where(q => q.Movie.Title == movie);
        }

        public IEnumerable<Quote> GetAllQuotesInDatabase()
        {
            return _context
                .Quotes
                .Include(q => q.Movie)
                .ToList();
        }

        public IEnumerable<Quote> GetAllUserQuotes(string userId)
        {
            return _context.Quotes
                .Include(q => q.Movie)
                .Where(q => q.UserId == userId)
                .ToList();
        }

        public Quote GetQuoteById(int id)
        {
            return _context.Quotes.SingleOrDefault(q => q.Id == id);
        }

        public void Add(Quote quote)
        {
            _context.Quotes.Add(quote);
        }

        public void Remove(Quote quoteInDb)
        {
            _context.Quotes.Remove(quoteInDb);
        }
    }
}
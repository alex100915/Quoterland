using System.Collections.Generic;
using System.Linq;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;
using System.Data.Entity;

namespace MyApplication.Persistence.Repositories
{
    public class LearningRepository : ILearningRepository
    {
        private readonly IApplicationDbContext _context;

        public LearningRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Learning GetUserLearningQuoteById(int id, string userId)
        {
            return _context.Learnings.SingleOrDefault(q => q.QuoteId == id && q.ApplicationUserId == userId);
        }

        public IEnumerable<Learning> GetUserLearningQuotes(string userId)
        {
            return _context.Learnings.Include(q=>q.Quote).Include(m=>m.Quote.Movie).Where(l => l.ApplicationUserId == userId).ToList();
        }

        public IEnumerable<Learning> GetUserLearningQuotesIds(string userId)
        {
            return _context.Learnings.Where(l => l.ApplicationUserId == userId).ToList();
        }

        public bool CheckQuoteExistsInLearnings(int id, string userId)
        {
            return _context.Learnings.Any(q => q.ApplicationUserId == userId && q.QuoteId == id);
        }

        public void Add(Learning learning)
        {
            _context.Learnings.Add(learning);
        }

        public void Remove(Learning quote)
        {
            _context.Learnings.Remove(quote);
        }
    }
}
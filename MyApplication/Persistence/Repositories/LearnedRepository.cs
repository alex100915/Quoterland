using System.Collections.Generic;
using System.Linq;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;

namespace MyApplication.Persistence.Repositories
{
    public class LearnedRepository : ILearnedRepository
    {
        private readonly IApplicationDbContext _context;

        public LearnedRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public bool CheckQuoteExistsInLearnedList(int id, string userId)
        {
            return _context.Learneds.Any(q => q.ApplicationUserId == userId && q.QuoteId == id);
        }

        public Learned GetUserLearnedQuoteById(int id, string userId)
        {
            return _context.Learneds.SingleOrDefault(q => q.QuoteId == id && q.ApplicationUserId == userId);
        }

        public IEnumerable<Learned> GetUserLearnedQuotes(string userId)
        {
            return _context.Learneds.Where(l => l.ApplicationUserId == userId).ToList();
        }

        public void Add(Learned learned)
        {
            _context.Learneds.Add(learned);
        }

        public void Remove(Learned quote)
        {
            _context.Learneds.Remove(quote);
        }
    }
}
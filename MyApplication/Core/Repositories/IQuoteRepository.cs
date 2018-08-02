using System.Collections.Generic;
using MyApplication.Core.Models;

namespace MyApplication.Core.Repositories
{
    public interface IQuoteRepository
    {
        IEnumerable<Quote> GetQuotesByMovieTitle(string movie);
        IEnumerable<Quote> GetAllQuotesInDatabase();
        IEnumerable<Quote> GetAllUserQuotes(string userId);
        Quote GetQuoteById(int id);
        void Add(Quote quote);
        void Remove(Quote quoteInDb);
        IEnumerable<Quote> GetUserLearnedQuotes(string userId);
        IEnumerable<Quote> GetUserLearningQuotes(string userId);
    }
}
using System.Collections.Generic;
using MyApplication.Core.Models;

namespace MyApplication.Core.Repositories
{
    public interface ILearningRepository
    {
        Learning GetUserLearningQuoteById(int id, string userId);
        IEnumerable<Learning> GetUserLearningQuotes(string userId);
        bool CheckQuoteExistsInLearnings(int id, string userId);
        void Add(Learning learning);
        void Remove(Learning quote);
        IEnumerable<Learning> GetUserLearningQuotesIds(string userId);
    }
}
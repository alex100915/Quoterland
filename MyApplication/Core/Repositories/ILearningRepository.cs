using System.Collections.Generic;
using MyApplication.Core.Models;

namespace MyApplication.Core.Repositories
{
    public interface ILearningRepository
    {
        Learning GetUserLearningQuoteById(byte id, string userId);
        IEnumerable<Learning> GetUserLearningQuotes(string userId);
        bool CheckQuoteExistsInLearnings(byte id, string userId);
        void Add(Learning learning);
        void Remove(Learning quote);
    }
}
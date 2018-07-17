using System.Collections.Generic;
using MyApplication.Core.Models;

namespace MyApplication.Core.Repositories
{
    public interface ILearnedRepository
    {
        bool CheckQuoteExistsInLearnedList(int id, string userId);
        Learned GetUserLearnedQuoteById(int id, string userId);
        IEnumerable<Learned> GetUserLearnedQuotes(string userId);
        void Add(Learned learned);
        void Remove(Learned quote);
    }
}
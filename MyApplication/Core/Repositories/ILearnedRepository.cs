using System.Collections.Generic;
using MyApplication.Core.Models;

namespace MyApplication.Core.Repositories
{
    public interface ILearnedRepository
    {
        bool CheckQuoteExistsInLearnedList(byte id, string userId);
        Learned GetUserLearnedQuoteById(byte id, string userId);
        IEnumerable<Learned> GetUserLearnedQuotes(string userId);
        void Add(Learned learned);
        void Remove(Learned quote);
    }
}
using System.Collections.Generic;
using MyApplication.Core.Models;

namespace MyApplication.Core.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllCommentsForQuote(int quoteId);
        void Add(Comment comment);
        Comment GetCommentById(string id);
        void Remove(Comment comment);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Core;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;

namespace MyApplication.Persistence.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly IApplicationDbContext _context;

        public CommentRepository(IApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Comment> GetAllCommentsForQuote(int quoteId)
        {
            return _context.Comments.Where(c => c.QuoteId == quoteId).ToList();
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public Comment GetCommentById(string id)
        {
            return _context.Comments.SingleOrDefault(c => c.Id == id);
        }

        public void Remove(Comment comment)
        {
            _context.Comments.Remove(comment);
        }
    }
}
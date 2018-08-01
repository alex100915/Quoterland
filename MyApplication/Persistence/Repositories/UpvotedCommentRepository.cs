using System;
using System.Collections.Generic;
using System.Linq;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;

namespace MyApplication.Persistence.Repositories
{
    public class UpvotedCommentRepository : IUpvotedCommentRepository
    {
        private readonly IApplicationDbContext _context;

        public UpvotedCommentRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public bool CheckUserUpvoteComment(string userId, int commentId)
        {
            return _context.UpvotedComments.Any(c => c.ApplicationUserId == userId && c.CommentId == commentId);
        }

        public UpvotedComment GetUpvoteComment(int commentId, string userId)
        {
            return _context.UpvotedComments.SingleOrDefault(c => c.ApplicationUserId == userId && c.CommentId == commentId);
        }

        public void Remove(UpvotedComment upvotedComment)
        {
            _context.UpvotedComments.Remove(upvotedComment);
        }

        public void Add(UpvotedComment newUpvotedComment)
        {
            _context.UpvotedComments.Add(newUpvotedComment);
        }
    }
}
using System.Collections.Generic;
using MyApplication.Core.Models;

namespace MyApplication.Core.Repositories
{
    public interface IUpvotedCommentRepository
    {
        bool CheckUserUpvoteComment(string userId, int commentId);
        UpvotedComment GetUpvoteComment(int commentId, string userId);
        void Remove(UpvotedComment upvotedComment);
        void Add(UpvotedComment newUpvotedComment);
    }
}
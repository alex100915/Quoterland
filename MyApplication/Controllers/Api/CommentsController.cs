using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MyApplication.Core;
using MyApplication.Core.Dtos;
using MyApplication.Core.Models;
using MyApplication.Persistence;

namespace MyApplication.Controllers.Api
{
    public class CommentsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("api/comments/getusers")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var users = _unitOfWork.ApplicationUsers.GetAllApplicationUsers();

            return Ok(users);
        }

        [Route("api/comments/getcurrentuser")]
        [HttpGet]
        public IHttpActionResult GetCurrentUser()
        {
            var userId = User.Identity.GetUserId();

            var currentUser = _unitOfWork.ApplicationUsers.GetUserById(userId);

            var userDto = Mapper.Map<ApplicationUser, ApplicationUserDto>(currentUser);

            return Ok(userDto);
        }

        [Route("api/comments/getallcomments/{id}")]
        [HttpGet]
        public IHttpActionResult GetAllComments(int id)
        {
            var allComments = _unitOfWork.Comments
                .GetAllCommentsForQuote(id)
                .Select(Mapper.Map<Comment, CommentDto>)
                .ToList();

            var userId = User.Identity.GetUserId();

            foreach (var comment in allComments)
            {
                if (comment.Creator == userId)
                {
                    comment.Created_by_current_user = true;
                    comment.Fullname = "You";
                }

                if (_unitOfWork.UpvotedComments.CheckUserUpvoteComment(userId, comment.CommentId))
                    comment.User_has_upvoted = true;

                if (comment.Creator == _unitOfWork.ApplicationUsers.GetUserIdByFullname("Movies Manager"))
                    comment.Created_by_admin = true;
            }

            return Ok(allComments);
        }

        [HttpPost]
        public IHttpActionResult AddComment(CommentDto commentDto, int id)
        {
            var comment = Mapper.Map<CommentDto, Comment>(commentDto);

            var userId = User.Identity.GetUserId();

            comment.Fullname = _unitOfWork.ApplicationUsers.GetUserById(userId).Fullname;
            comment.Creator = userId;
            comment.QuoteId = id;

            _unitOfWork.Comments.Add(comment);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteComments(string id)
        {
            _unitOfWork.Comments.Remove(_unitOfWork.Comments.GetCommentById(id));
            _unitOfWork.Complete();

            return Ok(id);
        }

        [HttpPut]
        [Route("api/comments/updatecomment/{id}")]
        public IHttpActionResult UpdateComment(string id, CommentDto commentDto)
        {
            var comment=_unitOfWork.Comments.GetCommentById(id);

            comment.Content = commentDto.Content;
            comment.Modified=DateTime.Now;

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        [Route("api/comments/upvotes/{id}")]
        public IHttpActionResult UpvoteComment(string id)
        {
            var comment = _unitOfWork.Comments.GetCommentById(id);

            var userId = User.Identity.GetUserId();

            if (_unitOfWork.UpvotedComments.CheckUserUpvoteComment(userId, comment.CommentId))
            {
                comment.Upvote_count--;

                _unitOfWork.UpvotedComments.Remove(
                    _unitOfWork.UpvotedComments.GetUpvoteComment(comment.CommentId, userId));
            }

            else
            {
                var newUpvotedComment = new UpvotedComment
                {
                    ApplicationUserId = User.Identity.GetUserId(),
                    CommentId = comment.CommentId
                };

                comment.Upvote_count++;
                _unitOfWork.UpvotedComments.Add(newUpvotedComment);
            }

            _unitOfWork.Complete();

            return Ok();
        }
    }
}

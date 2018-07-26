using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private readonly ApplicationDbContext _context;

        public CommentsController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("api/comments/getusers")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var users = _context.Users.ToList();

            return Ok(users);
        }

        [Route("api/comments/getcurrentuser")]
        [HttpGet]
        public IHttpActionResult GetCurrentUser()
        {
            var userId = User.Identity.GetUserId();

            var currentUser = _context.Users.SingleOrDefault(u => u.Id == userId);

            var userDto = Mapper.Map<ApplicationUser, ApplicationUserDto>(currentUser);

            return Ok(userDto);
        }

        [Route("api/comments/getallcomments/{id}")]
        [HttpGet]
        public IHttpActionResult GetAllComments(int id)
        {
            var allComments = _context.Comments.Where(c=>c.QuoteId==id).ToList().Select(Mapper.Map<Comment, CommentDto>).ToList();

            foreach (var comment in allComments)
            {
                if (comment.Creator == User.Identity.GetUserId())
                {
                    comment.Created_by_current_user = true;
                    comment.Fullname = "You";
                }

                var userId = User.Identity.GetUserId();
                var checkUserUpvoteComment =
                    _context.UpvotedComents.SingleOrDefault(c => c.ApplicationUserId == userId && c.CommentId==comment.CommentId);

                if (checkUserUpvoteComment != null)
                    comment.User_has_upvoted = true;
                else
                    comment.User_has_upvoted = false;

                if (comment.Creator == _context.Users.SingleOrDefault(u => u.Fullname == "Movies Manager").Id)
                    comment.Created_by_admin = true;

            }

            return Ok(allComments);
        }
        [HttpPost]
        public IHttpActionResult AddComment(CommentDto commentDto, int id)
        {
            var comment = Mapper.Map<CommentDto, Comment>(commentDto);

            var userId = User.Identity.GetUserId();

            comment.Fullname = _context.Users.SingleOrDefault(u => u.Id == userId).Fullname;

            comment.Creator = userId;



            comment.QuoteId = id;

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteComments(string id)
        {
            _context.Comments.Remove(_context.Comments.SingleOrDefault(c => c.Id == id));
            _context.SaveChanges();
            return Ok(id);
        }

        [HttpPut]
        [Route("api/comments/updatecomment/{id}")]
        public IHttpActionResult UpdateComment(string id, CommentDto commentDto)
        {
            var comment=_context.Comments.SingleOrDefault(c => c.Id == id);

            comment.Content = commentDto.Content;
            comment.Modified=DateTime.Now;

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("api/comments/upvotes/{id}")]
        public IHttpActionResult UpvoteComment(string id)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.Id == id);

            var userId = User.Identity.GetUserId();

            var upvoteComent = _context.UpvotedComents.SingleOrDefault(c =>
                c.CommentId == comment.CommentId && c.ApplicationUserId == userId);

            if (upvoteComent != null)
            {
                comment.Upvote_count--;

                _context.UpvotedComents.Remove(
                    _context.UpvotedComents.SingleOrDefault(u => u.CommentId == comment.CommentId && u.ApplicationUserId==userId));
            }

            else
            {
                var newUpvotedComment = new UpvotedComments
                {
                    ApplicationUserId = User.Identity.GetUserId(),
                    CommentId = comment.CommentId
                };
                comment.Upvote_count++;
                _context.UpvotedComents.Add(newUpvotedComment);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}

using System;
using MyApplication.Core.Models;

namespace MyApplication.Core.Dtos
{
    public class CommentDto
    {
        public int CommentId { get; set; }

        public string Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public string Fullname { get; set; }
        public string Profile_picture_url { get; set; }
        public string file_url { get; set; }
        public bool Created_by_admin { get; set; }
        public bool Created_by_current_user { get; set; }
        public int? Upvote_count { get; set; }
        public bool User_has_upvoted { get; set; }
    }
}
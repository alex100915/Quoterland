using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Web;

namespace MyApplication.Core.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Id { get; set; }
        public string Parent { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public string Fullname { get; set; }
        public string Profile_picture_url { get; set; }
        public string file_url { get; set; }
        public int? Upvote_count { get; set; }
        public int QuoteId { get; set; }
        public bool User_has_upvoted { get; set; }
    }
}
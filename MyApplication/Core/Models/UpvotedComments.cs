using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyApplication.Core.Models
{
    public class UpvotedComments
    {
        [Key]
        [Column(Order = 1)]
        public int CommentId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Comment Comment { get; set; }
    }
}
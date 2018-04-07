using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class Quote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        public string Content { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string PhraseToLearn { get; set; }

        public string MovieName { get; set; }

        public string YoutubeLink { get; set; }
    }
}
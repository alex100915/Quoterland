using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class Quote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(200)]
        public string Content { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string PhraseToLearn { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        [RegularExpression(@"^(http(s)??\:\/\/)?(www\.)?((youtube\.com\/watch\?v=)|(youtu.be\/))([a-zA-Z0-9\-_])+")]
        public string YoutubeLink { get; set; }
    }
}
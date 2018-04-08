using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApplication.Dtos
{
    public class QuoteDto
    {
        public byte Id { get; set; }

        public string Content { get; set; }

        public ApplicationUserDto User { get; set; }

        public string PhraseToLearn { get; set; }

        public MovieDto Movie { get; set; }

        public int MovieId { get; set; }

        public string YoutubeLink { get; set; }
    }
}
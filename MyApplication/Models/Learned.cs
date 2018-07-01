using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class Learned
    {
        [Key]
        [Column(Order =1)]
        public byte QuoteId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Quote Quote { get; set; }
    }
}
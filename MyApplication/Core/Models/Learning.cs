using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApplication.Core.Models
{
    public class Learning
    {
        [Key]
        [Column(Order = 1)]
        public byte QuoteId{ get; set; }
        [Key]
        [Column(Order = 2)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Quote Quote { get; set; }
    }
}
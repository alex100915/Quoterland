using System.ComponentModel.DataAnnotations;

namespace MyApplication.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        public ProductionType ProductionType { get; set; }

        public int? ProductionTypeId { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Genre { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }

        public ICollection<Review>? Reviews { get; set; } = new List<Review>();

        public ICollection<ReadingLog>? ReadingLogs { get; set; } = new List<ReadingLog>();
    }
}

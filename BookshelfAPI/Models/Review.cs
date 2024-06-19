using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfAPI.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public required string Content { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}

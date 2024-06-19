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

        public string UserId { get; set; } = string.Empty; // Ensure non-nullable

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookshelfAPI.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Biography { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

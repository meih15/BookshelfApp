namespace BookshelfAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Biography { get; set; }
        public required ICollection<Book> Books { get; set; }
    }
}

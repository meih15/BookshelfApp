namespace BookshelfAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public int AuthorId { get; set; }
        public required Author Author { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<ReadingLog>? ReadingLogs { get; set; }
    }
}

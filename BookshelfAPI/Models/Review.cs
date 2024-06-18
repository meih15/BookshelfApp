namespace BookshelfAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; }
        public required Book Book { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
    }
}

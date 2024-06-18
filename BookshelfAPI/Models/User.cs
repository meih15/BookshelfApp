namespace BookshelfAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<ReadingLog> ReadingLogs { get; set; } = new List<ReadingLog>();
    }
}

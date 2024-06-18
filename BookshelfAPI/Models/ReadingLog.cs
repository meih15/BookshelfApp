namespace BookshelfAPI.Models
{
    public class ReadingLog
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public required Book Book { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentPage { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfAPI.Models
{
    public class ReadingLog
    {
        public int Id { get; set; }

        public string? LogDetails { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        public string UserId { get; set; } = string.Empty; // Ensure non-nullable

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public int CurrentPage { get; set; }

        [Required]
        public ReadingStatus Status { get; set; } = ReadingStatus.WantToRead;
    }

    public enum ReadingStatus
    {
        WantToRead,
        CurrentlyReading,
        Finished,
        Dropped
    }
}

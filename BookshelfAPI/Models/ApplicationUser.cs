using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookshelfAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<ReadingLog> ReadingLogs { get; set; } = new List<ReadingLog>();

        private string? firstName;
        private string? lastName;

        public string? FirstName
        {
            get => firstName;
            set => firstName = value ?? throw new ArgumentNullException(nameof(FirstName));
        }

        public string? LastName
        {
            get => lastName;
            set => lastName = value ?? throw new ArgumentNullException(nameof(LastName));
        }
    }
}

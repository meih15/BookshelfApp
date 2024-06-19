using System.ComponentModel.DataAnnotations;

namespace BookshelfAPI.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public required string UserId { get; set; }
        
        [Required]
        public required string CurrentPassword { get; set; }
        
        [Required]
        public required string NewPassword { get; set; }
    }
}

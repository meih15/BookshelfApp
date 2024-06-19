using System.ComponentModel.DataAnnotations;

namespace BookshelfAPI.Models
{
    public class LoginModel
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}


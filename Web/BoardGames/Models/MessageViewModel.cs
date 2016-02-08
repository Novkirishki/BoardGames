namespace BoardGames.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MessageViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Message { get; set; }
    }
}
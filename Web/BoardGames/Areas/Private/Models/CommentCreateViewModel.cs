namespace BoardGames.Areas.Private.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentCreateViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }
    }
}
namespace BoardGames.Data.Models
{
    using BoardGames.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public int TutorialId { get; set; }

        public virtual Tutorial Tutorial { get; set; }
    }
}

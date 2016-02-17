namespace BoardGames.Data.Models
{
    using BoardGames.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Reply : BaseModel<int>
    {

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}

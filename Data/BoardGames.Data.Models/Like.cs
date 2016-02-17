namespace BoardGames.Data.Models
{
    using BoardGames.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Like : BaseModel<int>
    {
        [Required]
        public int TutorialId { get; set; }

        public virtual Tutorial Tutorial { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}

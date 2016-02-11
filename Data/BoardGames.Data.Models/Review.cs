namespace BoardGames.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Review : BaseModel<int>
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string GameTitle { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string Content { get; set; }

        [Range(1, 50, ErrorMessage = "The minimum players must be between {1} and {2}")]
        public int MinPlayers { get; set; }

        [Range(2, 50, ErrorMessage = "The maximum players must be between {1} and {2}")]
        public int MaxPlayers { get; set; }

        [Range(3, 18)]
        public int MinAgeRequired { get; set; }

        [Range(1, 6000)]
        public int MinPlayingTimeInMinutes { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        [MaxLength(2083)]
        public string UrlToOfficialSite { get; set; }
    }
}

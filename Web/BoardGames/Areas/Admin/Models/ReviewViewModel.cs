namespace BoardGames.Areas.Admin.Models
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using Web.Infrastructure.Mapping;
    using AutoMapper;
    using System;
    using Web.Infrastructure.Sanitizing;
    using System.Web.Mvc;

    public class ReviewViewModel : IMapFrom<Review>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string GameTitle { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        
        [AllowHtml]
        [Required]
        public string Content { get; set; }

        [UIHint("HtmlContent")]
        public string ContentSanitized => HtmlSanitizerAdapter.Sanitize(this.Content);

        [Range(1, 50, ErrorMessage = "The minimum players must be between {1} and {2}")]
        public int MinPlayers { get; set; }

        [Range(2, 50, ErrorMessage = "The maximum players must be between {1} and {2}")]
        public int MaxPlayers { get; set; }

        [Range(3, 18)]
        public int MinAgeRequired { get; set; }

        [Range(1, 6000)]
        public int MinPlayingTimeInMinutes { get; set; }

        public string Creator { get; set; }

        [MaxLength(2083)]
        [UIHint("Url")]
        public string UrlToOfficialSite { get; set; }

        [UIHint("ShortReviewDate")]
        public DateTime CreatedOn { get; set; }

        public int ImageId { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Review, ReviewViewModel>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.Name))
                .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Creator.UserName));
        }
    }
}
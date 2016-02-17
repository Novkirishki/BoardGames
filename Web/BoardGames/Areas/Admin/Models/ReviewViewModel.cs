namespace BoardGames.Areas.Admin.Models
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using Web.Infrastructure.Mapping;
    using AutoMapper;
    using System;
    using System.IO;
    public class ReviewViewModel : IMapFrom<Review>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string GameTitle { get; set; }

        public string Category { get; set; }

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

        public string Creator { get; set; }

        [MaxLength(2083)]
        public string UrlToOfficialSite { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ImageId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Review, ReviewViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
                .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Creator.UserName));
        }
    }
}
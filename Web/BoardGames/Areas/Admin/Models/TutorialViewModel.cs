namespace BoardGames.Areas.Admin.Models
{
    using BoardGames.Data.Models;
    using BoardGames.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using System;
    using System.Web.Mvc;
    using Web.Infrastructure.Sanitizing;

    public class TutorialViewModel : IMapFrom<Tutorial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        
        [AllowHtml]
        [Required]
        public string Content { get; set; }

        public string ContentSanitized => HtmlSanitizerAdapter.Sanitize(this.Content);

        [Required]
        [MaxLength(50)]
        public string Game { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ImageId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Tutorial, TutorialViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
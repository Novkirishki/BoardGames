namespace BoardGames.Areas.Private.Models
{
    using System;
    using AutoMapper;
    using BoardGames.Web.Infrastructure.Mapping;
    using BoardGames.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        [UIHint("ShortReviewDate")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
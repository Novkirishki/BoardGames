﻿namespace BoardGames.Areas.Private.Models
{
    using System;
    using AutoMapper;
    using BoardGames.Web.Infrastructure.Mapping;
    using BoardGames.Data.Models;
    using Web.Infrastructure.Sanitizing;

    public class TutorialListedViewModel : IMapFrom<Tutorial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ImageId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public string ContentSanitized => HtmlSanitizerAdapter.Sanitize(this.Content);

        public string GameTitle { get; set; }

        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Tutorial, TutorialListedViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(x => x.LikesCount, opt => opt.MapFrom(x => x.Likes.Count))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));
        }
    }
}
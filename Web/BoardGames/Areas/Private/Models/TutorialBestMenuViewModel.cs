namespace BoardGames.Areas.Private.Models
{
    using AutoMapper;
    using BoardGames.Web.Infrastructure.Mapping;
    using Data.Models;

    public class TutorialBestMenuViewModel : IMapFrom<Tutorial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Likes { get; set; }

        public int ImageId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Tutorial, TutorialBestMenuViewModel>()
                .ForMember(x => x.Likes, opt => opt.MapFrom(x => x.Likes.Count));
        }
    }
}
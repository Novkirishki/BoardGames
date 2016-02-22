namespace BoardGames.Areas.Admin.Models
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using Web.Infrastructure.Mapping;
    using AutoMapper;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        public int Tutorials { get; set; }

        public int Comments { get; set; }

        public int Likes { get; set; }

        public int Reviews { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(x => x.IsAdmin, opt => opt.MapFrom(x => x.Roles.Count >= 1))
                .ForMember(x => x.Tutorials, opt => opt.MapFrom(x => x.Tutorials.Count))
                .ForMember(x => x.Comments, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.Reviews, opt => opt.MapFrom(x => x.Reviews.Count))
                .ForMember(x => x.Likes, opt => opt.MapFrom(x => x.Likes.Count));
        }
    }
}
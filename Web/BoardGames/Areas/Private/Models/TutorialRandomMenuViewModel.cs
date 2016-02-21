namespace BoardGames.Areas.Private.Models
{
    using BoardGames.Data.Models;
    using BoardGames.Web.Infrastructure.Mapping;

    public class TutorialRandomMenuViewModel : IMapFrom<Tutorial>
    {
        public int Id { get; set; }

        public int ImageId { get; set; }
    }
}
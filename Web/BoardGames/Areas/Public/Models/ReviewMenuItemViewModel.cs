namespace BoardGames.Areas.Public.Models
{
    using Data.Models;
    using System;
    using Web.Infrastructure.Mapping;

    public class ReviewMenuItemViewModel : IMapFrom<Review>
    {
        public int Id { get; set; }

        public string GameTitle { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ImageId { get; set; }
    }
}
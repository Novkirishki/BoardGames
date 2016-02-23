namespace BoardGames.Areas.Public.Models
{
    using Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using Web.Infrastructure.Mapping;

    public class ReviewMenuItemViewModel : IMapFrom<Review>
    {
        public int Id { get; set; }

        public string GameTitle { get; set; }

        [UIHint("LongDate")]
        public DateTime CreatedOn { get; set; }

        public int ImageId { get; set; }
    }
}
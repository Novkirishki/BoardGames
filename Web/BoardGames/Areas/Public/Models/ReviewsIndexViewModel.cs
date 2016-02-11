namespace BoardGames.Areas.Public.Models
{
    using BoardGames.Models;
    using System.Collections.Generic;

    public class ReviewsIndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<ReviewMenuItemViewModel> LatestReviews { get; set; }

        public IEnumerable<ReviewMenuItemViewModel> Reviews { get; set; }
    }
}
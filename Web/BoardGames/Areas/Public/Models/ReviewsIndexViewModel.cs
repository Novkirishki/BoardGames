namespace BoardGames.Areas.Public.Models
{
    using BoardGames.Models;
    using System.Collections.Generic;

    public class ReviewsIndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
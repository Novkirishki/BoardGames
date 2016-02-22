namespace BoardGames.Areas.Private.Models
{
    using System.Collections.Generic;

    public class CommentsViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }

        public int Pages { get; set; }
    }
}
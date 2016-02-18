namespace BoardGames.Areas.Private.Models
{
    using System.Collections.Generic;

    public class TutorialsIndexViewModel
    {
        public IEnumerable<TutorialBestMenuViewModel> BestTutorials { get; set; }

        public IEnumerable<TutorialRandomMenuViewItem> RandomTutorials { get; set; }

        public IEnumerable<TutorialListedViewModel> Tutorials { get; set; }

        public int PagesCount { get; set; }
    }
}
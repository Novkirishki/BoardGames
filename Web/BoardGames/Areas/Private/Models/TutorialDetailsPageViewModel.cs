using System.Collections.Generic;

namespace BoardGames.Areas.Private.Models
{
    public class TutorialDetailsPageViewModel
    {

        public IEnumerable<TutorialBestMenuViewModel> BestTutorials { get; set; }

        public IEnumerable<TutorialRandomMenuViewModel> RandomTutorials { get; set; }

        public TutorialListedViewModel Tutorial { get; set; }
    }
}
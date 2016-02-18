namespace BoardGames.Areas.Private.Controllers
{
    using Models;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using Web.Infrastructure.Mapping;

    public class TutorialsController : Controller
    {
        private readonly ITutorialsService tutorials;

        public TutorialsController(ITutorialsService tutorials)
        {
            this.tutorials = tutorials;
        }

        // GET: Public/Reviews
        public ActionResult Index(int page = 1)
        {
            var model = new TutorialsIndexViewModel();

            //if (this.HttpContext.Cache.Get("Categories") != null)
            //{
            //    model.Categories = (List<CategoryViewModel>)this.HttpContext.Cache.Get("Categories");
            //}
            //else
            //{
            //    model.Categories = this.categories.GetAll().To<CategoryViewModel>().ToList();
            //    this.HttpContext.Cache.Add("Categories", model.Categories, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            //}

            //if (this.HttpContext.Cache.Get("LatestReviews") != null)
            //{
            //    model.LatestReviews = (List<ReviewMenuItemViewModel>)this.HttpContext.Cache.Get("LatestReviews");
            //}
            //else
            //{
            //    model.LatestReviews = this.reviews.GetLatest(3).To<ReviewMenuItemViewModel>().ToList();
            //    this.HttpContext.Cache.Add("LatestReviews", model.LatestReviews, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            //}

            model.RandomTutorials = this.tutorials.GetRandom().To<TutorialRandomMenuViewModel>().ToList();
            model.BestTutorials = this.tutorials.GetBest().To<TutorialBestMenuViewModel>().ToList();
            return View(model);
        }
    }
}
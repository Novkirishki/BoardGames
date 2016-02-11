namespace BoardGames.Areas.Public.Controllers
{
    using BoardGames.Models;
    using Models;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using Web.Infrastructure.Mapping;

    public class ReviewsController : Controller
    {
        private readonly IReviewsService reviews;
        private readonly ICategoriesService categories;

        public ReviewsController(IReviewsService reviews, ICategoriesService categories)
        {
            this.reviews = reviews;
            this.categories = categories;
        }

        // GET: Public/Reviews
        public ActionResult Index(string category, int page)
        {
            var model = new ReviewsIndexViewModel();
            model.Categories = this.categories.GetAll().To<CategoryViewModel>().ToList();
            model.LatestReviews = this.reviews.GetLatest(3).To<ReviewMenuItemViewModel>().ToList();
            model.Reviews = this.reviews.GetByPageAndCategory(category, page).To<ReviewMenuItemViewModel>().ToList();
            model.PagesCount = this.reviews.GetPagesCountByCategory(category);
            return View(model);
        }
    }
}
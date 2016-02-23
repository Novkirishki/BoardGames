namespace BoardGames.Areas.Public.Controllers
{
    using Admin.Models;
    using Data.Models;
    using Models;
    using Services.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Caching;
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
        public ActionResult Index(string category, int page = 1)
        {
            var model = new ReviewsIndexViewModel();

            if (this.HttpContext.Cache.Get("Categories") != null)
            {
                model.Categories = (List<CategoryViewModel>)this.HttpContext.Cache.Get("Categories");
            }
            else
            {
                model.Categories = this.categories.GetAll().To<CategoryViewModel>().ToList();
                this.HttpContext.Cache.Add("Categories", model.Categories, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            }

            if (this.HttpContext.Cache.Get("LatestReviews") != null)
            {
                model.LatestReviews = (List<ReviewMenuItemViewModel>)this.HttpContext.Cache.Get("LatestReviews");
            }
            else
            {
                model.LatestReviews = this.reviews.GetLatest(3).To<ReviewMenuItemViewModel>().ToList();
                this.HttpContext.Cache.Add("LatestReviews", model.LatestReviews, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            }
            
            model.Reviews = this.reviews.GetByPageAndCategory(category, page).To<ReviewMenuItemViewModel>().ToList();
            model.PagesCount = this.reviews.GetPagesCountByCategory(category);
            return View(model);
        }

        // GET: Public/Reviews
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Review review = this.reviews.GetById((int)id);
            if (review == null)
            {
                return HttpNotFound();
            }

            var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<ReviewViewModel>(review);
            return View(viewModel);
        }
    }
}
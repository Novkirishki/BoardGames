namespace BoardGames.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using BoardGames.Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using Models;
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

        // GET: Admin/Reviews
        public ActionResult Index()
        {
            var allReviews = this.reviews.GetAll().To<ReviewViewModel>().ToList();
            return View(allReviews);
        }

        // GET: Admin/Reviews/Details/5
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

        // GET: Admin/Reviews/Create
        public ActionResult Create()
        {
            var categories = this.categories.GetAll().To<CategoryViewModel>().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.reviews.Add(
                    model.GameTitle,
                    model.CategoryId,
                    model.Content,
                    model.MinPlayers,
                    model.MaxPlayers,
                    model.MinAgeRequired,
                    model.MinPlayingTimeInMinutes,
                    model.UrlToOfficialSite,
                    User.Identity.GetUserId());

                return RedirectToAction("Index");
            }

            var categories = this.categories.GetAll().To<CategoryViewModel>().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View(model);
        }

        // GET: Admin/Reviews/Edit/5
        public ActionResult Edit(int? id)
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

            var categories = this.categories.GetAll().To<CategoryViewModel>().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<ReviewCreateViewModel>(review);
            return View(viewModel);
        }

        // POST: Admin/Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReviewCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.reviews.Edit(
                    model.Id,
                    model.GameTitle,
                    model.CategoryId,
                    model.Content,
                    model.MinPlayers,
                    model.MaxPlayers,
                    model.MinAgeRequired,
                    model.MinPlayingTimeInMinutes,
                    model.UrlToOfficialSite);

                return RedirectToAction("Index");
            }

            var categories = this.categories.GetAll().To<CategoryViewModel>().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View(model);
        }

        // GET: Admin/Reviews/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.reviews.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

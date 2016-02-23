namespace BoardGames.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using BoardGames.Services.Data.Contracts;
    using Models;
    using Web.Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using Common;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ReviewsController : Controller
    {
        private readonly IReviewsService reviews;
        private readonly ICategoriesService categories;
        private readonly IFilesService files;

        public ReviewsController(IReviewsService reviews, ICategoriesService categories, IFilesService files)
        {
            this.reviews = reviews;
            this.categories = categories;
            this.files = files;
        }

        public ActionResult Index()
        {
            var categories = this.categories.GetAll().To<Models.CategoryViewModel>().ToList();
            ViewData["categories"] = categories;

            return View();
        }

        public ActionResult Reviews_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.reviews
                .GetAll()
                .To<ReviewViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Reviews_Create([DataSourceRequest]DataSourceRequest request, ReviewViewModel model)
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
                    User.Identity.GetUserId(),
                    model.ImageId);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Reviews_Update([DataSourceRequest]DataSourceRequest request, ReviewViewModel model)
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
                    model.UrlToOfficialSite,
                    model.ImageId);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Reviews_Destroy([DataSourceRequest]DataSourceRequest request, ReviewViewModel model)
        {
            this.reviews.Delete(model.Id);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}

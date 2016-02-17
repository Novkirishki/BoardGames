namespace BoardGames.Areas.Admin.Controllers
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using BoardGames.Data.Models;
    using Services.Data.Contracts;
    using Models;
    using Web.Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using System.Web;

    public class TutorialsController : Controller
    {
        private readonly ITutorialsService tutorials;
        private readonly IFilesService files;

        public TutorialsController(ITutorialsService tutorials, IFilesService files)
        {
            this.tutorials = tutorials;
            this.files = files;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tutorials_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.tutorials
                .GetAll()
                .To<TutorialViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tutorials_Create([DataSourceRequest]DataSourceRequest request, TutorialViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.tutorials.Add(
                    model.Title,
                    model.Game,
                    model.Content,
                    User.Identity.GetUserId(),
                    model.ImageId
                    );
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tutorials_Update([DataSourceRequest]DataSourceRequest request, TutorialViewModel model)
        {

            if (ModelState.IsValid)
            {
                this.tutorials.Edit(
                    model.Id,
                    model.Title,
                    model.Game,
                    model.Content,
                    model.ImageId);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tutorials_Destroy([DataSourceRequest]DataSourceRequest request, TutorialViewModel model)
        {
            this.tutorials.Delete(model.Id);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}

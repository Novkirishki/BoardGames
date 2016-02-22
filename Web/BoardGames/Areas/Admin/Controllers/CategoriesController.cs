namespace BoardGames.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using BoardGames.Data.Models;
    using Models;
    using Services.Data.Contracts;
    using Web.Infrastructure.Mapping;
    using System.Linq;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.categories
                .GetAll()
                .To<CategoryViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Create([DataSourceRequest]DataSourceRequest request, Category model)
        {
            if (ModelState.IsValid)
            {
                this.categories.Add(model.Name);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Update([DataSourceRequest]DataSourceRequest request, Category model)
        {
            if (ModelState.IsValid)
            {
                this.categories.Edit(model.Id, model.Name);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Destroy([DataSourceRequest]DataSourceRequest request, Category model)
        {
            this.categories.Delete(model.Id);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}

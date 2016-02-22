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

    public class CommentsController : Controller
    {
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.comments
                .GetAll()
                .To<CommentViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.comments.Edit(model.Id, model.Content);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Destroy([DataSourceRequest]DataSourceRequest request, CommentViewModel model)
        {
            this.comments.Delete(model.Id);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}

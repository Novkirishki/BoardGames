namespace BoardGames.Areas.Admin.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using BoardGames.Data.Models;
    using Services.Data.Contracts;
    using Models;
    using Web.Infrastructure.Mapping;
    public class UsersController : Controller
    {
        private readonly IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.users
                .GetAll()
                .To<UserViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Create([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.users.Create(
                    model.Email,
                    model.UserName,
                    model.Password,
                    model.IsAdmin);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.users.Edit(
                    model.Id,
                    model.Email,
                    model.UserName,
                    model.Password,
                    model.IsAdmin);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            this.users.Delete(model.Id);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}

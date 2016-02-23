namespace BoardGames.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Common;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
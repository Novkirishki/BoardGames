namespace BoardGames.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BadRequest()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
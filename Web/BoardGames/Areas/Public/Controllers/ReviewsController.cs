namespace BoardGames.Areas.Public.Controllers
{
    using System.Web.Mvc;

    public class ReviewsController : Controller
    {
        // GET: Public/Reviews
        public ActionResult Index()
        {
            return View();
        }
    }
}
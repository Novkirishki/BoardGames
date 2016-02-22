namespace BoardGames.Controllers
{
    using Models;
    using Services.Data;
    using System.Web.Mvc;

    public class StatisticsController : Controller
    {

        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics)
        {
            this.statistics = statistics;
        }

        public ActionResult Statistics()
        {
            var result = new StatisticsViewModel();
            var stats = this.statistics.GetStatistics();

            result.Reviews = stats[0];
            result.Tutorials = stats[1];
            result.Comments = stats[2];
            result.Likes = stats[3];

            return this.PartialView("_StatisticsPartial", result);
        }
    }
}
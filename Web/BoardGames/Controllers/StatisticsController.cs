namespace BoardGames.Controllers
{
    using Models;
    using Services.Data;
    using System;
    using System.Web.Caching;
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
            var model = new StatisticsViewModel();

            if (this.HttpContext.Cache.Get("Stats") != null)
            {
                model.Reviews = ((int[])this.HttpContext.Cache.Get("Stats"))[0];
                model.Tutorials = ((int[])this.HttpContext.Cache.Get("Stats"))[1];
                model.Comments = ((int[])this.HttpContext.Cache.Get("Stats"))[2];
                model.Likes = ((int[])this.HttpContext.Cache.Get("Stats"))[3];
            }
            else
            {
                var stats = this.statistics.GetStatistics();

                model.Reviews = stats[0];
                model.Tutorials = stats[1];
                model.Comments = stats[2];
                model.Likes = stats[3];

                this.HttpContext.Cache.Add("Stats", stats, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            }

            return this.PartialView("_StatisticsPartial", model);
        }
    }
}
﻿namespace BoardGames.Areas.Private.Controllers
{
    using Models;
    using Services.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using Web.Infrastructure.Mapping;

    public class TutorialsController : Controller
    {
        private readonly ITutorialsService tutorials;

        public TutorialsController(ITutorialsService tutorials)
        {
            this.tutorials = tutorials;
        }

        // GET: Public/Reviews
        public ActionResult Index(int page = 1)
        {
            var model = new TutorialsIndexViewModel();

            if (this.HttpContext.Cache.Get("BestTutorials") != null)
            {
                model.BestTutorials = (List<TutorialBestMenuViewModel>)this.HttpContext.Cache.Get("BestTutorials");
            }
            else
            {
                model.BestTutorials = this.tutorials.GetBest().To<TutorialBestMenuViewModel>().ToList();
                this.HttpContext.Cache.Add("BestTutorials", model.BestTutorials, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            }

            if (this.HttpContext.Cache.Get("RandomTutorials") != null)
            {
                model.RandomTutorials = (List<TutorialRandomMenuViewModel>)this.HttpContext.Cache.Get("RandomTutorials");
            }
            else
            {
                model.RandomTutorials = this.tutorials.GetRandom().To<TutorialRandomMenuViewModel>().ToList();
                this.HttpContext.Cache.Add("RandomTutorials", model.RandomTutorials, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 3, 0), CacheItemPriority.Normal, null);
            }

            model.PagesCount = this.tutorials.GetPagesCount();
            model.Tutorials = this.tutorials.GetByPage(page).To<TutorialListedViewModel>().ToList();
            return View(model);
        }
    }
}
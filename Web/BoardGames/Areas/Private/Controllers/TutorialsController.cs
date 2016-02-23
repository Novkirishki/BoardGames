namespace BoardGames.Areas.Private.Controllers
{
    using Admin.Models;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using Services.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Caching;
    using System.Web.Mvc;
    using Web.Infrastructure.Mapping;

    [Authorize]
    public class TutorialsController : Controller
    {
        private readonly ITutorialsService tutorials;
        private readonly ILikesService likes;

        public TutorialsController(ITutorialsService tutorials, ILikesService likes)
        {
            this.tutorials = tutorials;
            this.likes = likes;
        }

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
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tutorial tutorial = this.tutorials.GetById((int)id);

            if (tutorial == null)
            {
                return HttpNotFound();
            }

            var model = new TutorialDetailsPageViewModel();

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

            model.Tutorial = AutoMapperConfig.Configuration.CreateMapper().Map<TutorialListedViewModel>(tutorial);
            model.Tutorial.IsLikedByUser = (this.likes.GetByUserIdAndTutorialId(model.Tutorial.Id, User.Identity.GetUserId()) != null);
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View(new TutorialViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TutorialViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var id = this.tutorials.Add(model.Title, model.Game, Server.HtmlDecode(model.Content), User.Identity.GetUserId(), model.ImageId);

            return RedirectToAction("Details", "Tutorials", new { id = id });
        }
    }
}
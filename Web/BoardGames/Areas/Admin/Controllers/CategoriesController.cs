namespace BoardGames.Areas.Admin.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using BoardGames.Data.Models;
    using Services.Data.Contracts;
    using Web.Infrastructure.Mapping;
    using System.Linq;
    using BoardGames.Models;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        // GET: Admin/Categories
        public ActionResult Index()
        {
            var allCategories = this.categories.GetAll().To<CategoryViewModel>().ToList();
            return View(allCategories);
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.categories.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<CategoryViewModel>(category);
            return View(viewModel);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.categories.Add(model.Name);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.categories.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<CategoryViewModel>(category);
            return View(viewModel);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                this.categories.Edit(id, model.Name);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.categories.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<CategoryViewModel>(category);
            return View(viewModel);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.categories.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

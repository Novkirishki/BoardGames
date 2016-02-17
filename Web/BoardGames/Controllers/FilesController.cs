namespace BoardGames.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Mvc;

    public class FilesController : Controller
    {
        private readonly IFilesService files;

        public FilesController(IFilesService files)
        {
            this.files = files;
        }

        public ActionResult Index(int id)
        {
            var fileToRetrieve = files.GetById(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}
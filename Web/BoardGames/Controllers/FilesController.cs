namespace BoardGames.Controllers
{
    using Services.Data.Contracts;
    using System.Web;
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
            if (id == 0)
            {
                return null;
            }
            var fileToRetrieve = files.GetById(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }

        public ActionResult Upload(HttpPostedFileBase upload)
        {
            int? imageId = null;

            if (upload != null && upload.ContentLength > 0)
            {
                var imageType = upload.ContentType;
                byte[] content = null;
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    content = reader.ReadBytes(upload.ContentLength);
                }

                imageId = this.files.Add(imageType, content);
            }

            return Json(new { imageId }, "text/plain");
        }
    }
}
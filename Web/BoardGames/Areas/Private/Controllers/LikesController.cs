namespace BoardGames.Areas.Private.Controllers
{
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System.Web.Mvc;

    [Authorize]
    public class LikesController : Controller
    {
        private readonly ILikesService likes;

        public LikesController(ILikesService likes)
        {
            this.likes = likes;
        }

        [HttpPost]
        public ActionResult Like(int tutorialId)
        {
            var isLikedByUser = false;
            var userId = User.Identity.GetUserId();

            var currentLike = this.likes.GetByUserIdAndTutorialId(tutorialId, userId);
            if (currentLike == null)
            {
                this.likes.Add(tutorialId, userId);
                isLikedByUser = true;
            }
            else
            {
                this.likes.Delete(currentLike.Id);
            }

            return Json(new { Count = this.likes.GetCount(), IsLikedByUser = isLikedByUser});
        }
    }
}
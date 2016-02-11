namespace BoardGames.Services.Data
{
    using Contracts;
    using System.Linq;
    using BoardGames.Data.Models;
    using BoardGames.Data.Common;

    public class ReviewsService : IReviewsService
    {
        private readonly IDbRepository<Review> reviews;

        public ReviewsService(IDbRepository<Review> reviews)
        {
            this.reviews = reviews;
        }

        public void Add(string gameTitle, int categoryId, string content, int minPlayers, int maxPlayers, int minAge, int minTime, string siteUrl, string creatorId)
        {
            var newReview = new Review
            {
                GameTitle = gameTitle,
                CategoryId = categoryId,
                Content = content,
                MinPlayers = minPlayers,
                MaxPlayers = maxPlayers,
                MinAgeRequired = minAge,
                MinPlayingTimeInMinutes = minTime,
                UrlToOfficialSite = siteUrl,
                CreatorId = creatorId
            };

            this.reviews.Add(newReview);
            this.reviews.Save();
        }

        public void Delete(int id)
        {
            var reviewToBeDeleted = this.reviews.GetById(id);
            this.reviews.Delete(reviewToBeDeleted);
            this.reviews.Save();
        }

        public void Edit(int id, string gameTitle, int categoryId, string content, int minPlayers, int maxPlayers, int minAge, int minTime, string siteUrl)
        {
            var reviewToBeEdited = this.reviews.GetById(id);
            reviewToBeEdited.GameTitle = gameTitle;
            reviewToBeEdited.CategoryId = categoryId;
            reviewToBeEdited.Content = content;
            reviewToBeEdited.MinPlayers = minPlayers;
            reviewToBeEdited.MaxPlayers = maxPlayers;
            reviewToBeEdited.MinAgeRequired = minAge;
            reviewToBeEdited.MinPlayingTimeInMinutes = minTime;
            reviewToBeEdited.UrlToOfficialSite = siteUrl;
            this.reviews.Save();
        }

        public IQueryable<Review> GetAll()
        {
            return this.reviews.All();
        }

        public Review GetById(int id)
        {
            return this.reviews.GetById(id);
        }

        public IQueryable<Review> GetByPageAndCategory(string category, int page)
        {
            var result = this.reviews.All();

            if (category != null)
            {
                result = result.Where(r => r.Category.Name == category);
            }

            return result
                .OrderByDescending(r => r.CreatedOn)
                .Skip((page - 1) * 12)
                .Take(12);
        }

        public IQueryable<Review> GetLatest(int count)
        {
            return this.reviews.All().OrderByDescending(r => r.CreatedOn).Take(count);
        }
    }
}

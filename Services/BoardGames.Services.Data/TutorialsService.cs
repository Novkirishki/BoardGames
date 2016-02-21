namespace BoardGames.Services.Data
{
    using BoardGames.Services.Data.Contracts;
    using System;
    using System.Linq;
    using BoardGames.Data.Models;
    using BoardGames.Data.Common;

    public class TutorialsService : ITutorialsService
    {
        private const int PAGE_SIZE = 6;
        private readonly IDbRepository<Tutorial> tutorials;

        public TutorialsService(IDbRepository<Tutorial> tutorials)
        {
            this.tutorials = tutorials;
        }

        public void Add(string title, string gameTitle, string content, string creatorId, int? imageId = null)
        {
            var newTutorial = new Tutorial
            {
                Title = title,
                Game = gameTitle,
                Content = content,
                AuthorId = creatorId
            };

            if (imageId != null)
            {
                newTutorial.ImageId = (int)imageId;
            }
            else
            {
                newTutorial.ImageId = 1;
            }

            this.tutorials.Add(newTutorial);
            this.tutorials.Save();
        }

        public void Delete(int id)
        {
            var tutorialToBeDeleted = this.tutorials.GetById(id);
            this.tutorials.Delete(tutorialToBeDeleted);
            this.tutorials.Save();
        }

        public void Edit(int id, string title, string gameTitle, string content, int? imageId = null)
        {
            var tutorialToBeEdited = this.tutorials.GetById(id);
            tutorialToBeEdited.Title = title;
            tutorialToBeEdited.Game = gameTitle;
            tutorialToBeEdited.Content = content;

            if (imageId != null)
            {
                tutorialToBeEdited.ImageId = (int)imageId;
            }

            this.tutorials.Save();
        }

        public IQueryable<Tutorial> GetAll()
        {
            return this.tutorials.All();
        }

        public IQueryable<Tutorial> GetBest(int count = 5)
        {
            return this.tutorials.All().OrderByDescending(t => t.Likes.Count).Take(count);
        }

        public Tutorial GetById(int id)
        {
            return this.tutorials.GetById(id);
        }

        public IQueryable<Tutorial> GetByPage(int page = 1)
        {
            return this.tutorials.All().OrderBy(t => t.CreatedOn).Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
        }

        public int GetPagesCount()
        {
            return (int) Math.Ceiling(this.tutorials.All().Count() / (decimal)PAGE_SIZE);
        }

        public IQueryable<Tutorial> GetRandom(int count = 6)
        {
            return this.tutorials.All().OrderBy(r => Guid.NewGuid()).Take(count);
        }
    }
}

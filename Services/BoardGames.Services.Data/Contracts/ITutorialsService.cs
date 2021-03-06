﻿namespace BoardGames.Services.Data.Contracts
{
    using BoardGames.Data.Models;
    using System.Linq;

    public interface ITutorialsService
    {
        IQueryable<Tutorial> GetAll();

        int Add(string title, string gameTitle, string content, string creatorId, int? imageId = null);

        void Edit(int id, string title, string gameTitle, string content, int? imageId = null);

        void Delete(int id);

        Tutorial GetById(int id);

        IQueryable<Tutorial> GetBest(int count = 5);

        IQueryable<Tutorial> GetRandom(int count = 6);

        IQueryable<Tutorial> GetByPage(int page = 1);

        int GetPagesCount();
    }
}

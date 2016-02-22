namespace BoardGames.Services.Data.Contracts
{
    using BoardGames.Data.Models;
    using System.Linq;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAll();

        void Add(string content, string authorId, int tutorialId);

        void Edit(int id, string content);

        void Delete(int id);

        IQueryable<Comment> GetByPage(int tutorialId, int page);

        int GetPagesCount(int tutorialId);
    }
}

namespace BoardGames.Services.Data.Contracts
{
    using BoardGames.Data.Models;

    public interface ILikesService
    {
        void Add(int tutorialId, string userId);

        void Delete(int id);

        Like GetByUserIdAndTutorialId(int tutorialId, string userId);

        int GetCountByTutorialId(int tutorialId);
    }
}

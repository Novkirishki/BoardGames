namespace BoardGames.Services.Data.Contracts
{
    using BoardGames.Data.Models;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        void Create(string email, string username, string password, bool isAdmin);

        void Edit(string id, string email, string username, string password, bool isAdmin);

        void Delete(string id);
    }
}

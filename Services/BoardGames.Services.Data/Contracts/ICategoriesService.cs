namespace BoardGames.Services.Data.Contracts
{
    using BoardGames.Data.Models;
    using System.Linq;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        void Add(string name);

        void Edit(int id, string name);

        void Delete(int id);

        Category GetById(int id);
    }
}

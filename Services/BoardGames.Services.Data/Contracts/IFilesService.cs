namespace BoardGames.Services.Data.Contracts
{
    using BoardGames.Data.Models;

    public interface IFilesService
    {
        int Add(string fileType, byte[] content);

        int Edit(int id, string fileType, byte[] content);

        File GetById(int id);
    }
}

namespace BoardGames
{
    using BoardGames.Data;
    using BoardGames.Data.Migrations;
    using System.Data.Entity;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BoardGamesDbContext, Configuration>());
            BoardGamesDbContext.Create().Database.Initialize(true);
        }
    }
}
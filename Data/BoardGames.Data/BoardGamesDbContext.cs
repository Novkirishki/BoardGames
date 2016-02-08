namespace BoardGames.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class BoardGamesDbContext : IdentityDbContext<User>
    {
        public BoardGamesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BoardGamesDbContext Create()
        {
            return new BoardGamesDbContext();
        }

        public System.Data.Entity.DbSet<BoardGames.Data.Models.Category> Categories { get; set; }
    }
}

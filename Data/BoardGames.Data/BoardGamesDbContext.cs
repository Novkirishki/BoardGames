﻿namespace BoardGames.Data
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

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public static BoardGamesDbContext Create()
        {
            return new BoardGamesDbContext();
        }
    }
}

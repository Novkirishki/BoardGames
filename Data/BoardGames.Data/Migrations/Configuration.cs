namespace BoardGames.Data.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Data.BoardGamesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Data.BoardGamesDbContext context)
        {
            if(!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category() { Name = "Action" },
                    new Category() { Name = "Active" },
                    new Category() { Name = "RPG" },
                    new Category() { Name = "Fun" },
                    new Category() { Name = "Cards" },
                    new Category() { Name = "Luck" },
                    new Category() { Name = "Strategy" },
                    new Category() { Name = "Sports" },
                    new Category() { Name = "Fantasy" },
                };

                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                }
            }
        }
    }
}

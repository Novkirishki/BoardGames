namespace BoardGames.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Hosting;

    public sealed class Configuration : DbMigrationsConfiguration<Data.BoardGamesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Data.BoardGamesDbContext context)
        {
            //Admin
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = "admin";

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Administrator" };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, "Administrator");
            }

            // Categories
            if (!context.Categories.Any())
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

            // Files
            if (!context.Files.Any())
            {
                // Image
                var defaultReviewImage = new Models.File
                {
                    ContentType = "image/png",
                    Content = System.IO.File.ReadAllBytes(this.MapPath("~/Images/review_default.png"))
                };

                context.Files.Add(defaultReviewImage);
            }
        }

        private string MapPath(string seedFile)
        {
            if (HttpContext.Current != null)
            {
                return HostingEnvironment.MapPath(seedFile);
            }

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, ".." + seedFile.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}

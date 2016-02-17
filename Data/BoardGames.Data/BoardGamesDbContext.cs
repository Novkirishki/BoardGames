namespace BoardGames.Data
{
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BoardGamesDbContext : IdentityDbContext<User>
    {
        public BoardGamesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<File> Files { get; set; }

        public IDbSet<Tutorial> Tutorials { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Reply> Replies { get; set; }

        public static BoardGamesDbContext Create()
        {
            return new BoardGamesDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Reply>()
                .HasRequired(r => r.Author)
                .WithMany()
                .WillCascadeOnDelete(false);


            modelBuilder
                .Entity<Comment>()
                .HasRequired(r => r.Author)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}

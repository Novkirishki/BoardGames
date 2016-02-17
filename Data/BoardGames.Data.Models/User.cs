namespace BoardGames.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        public User()
        {
            this.Tutorials = new HashSet<Tutorial>();
            this.Reviews = new HashSet<Review>();
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
            this.Replies = new HashSet<Reply>();
        }

        public virtual ICollection<Tutorial> Tutorials { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}

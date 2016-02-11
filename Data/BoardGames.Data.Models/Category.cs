namespace BoardGames.Data.Models
{
    using Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseModel<int>
    {
        private ICollection<Review> reviews;

        public Category()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
            }
        }
    }
}
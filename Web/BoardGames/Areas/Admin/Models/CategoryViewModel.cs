namespace BoardGames.Areas.Admin.Models
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
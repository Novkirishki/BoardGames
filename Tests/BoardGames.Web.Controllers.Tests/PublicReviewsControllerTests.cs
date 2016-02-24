namespace BoardGames.Web.Controllers.Tests
{
    using Areas.Admin.Models;
    using Areas.Public.Controllers;
    using Data.Models;
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class PublicReviewsControllerTests
    {
        private ReviewsController reviewsController;
        private const int reviewId = 13;
        private const int page = 2;
        private const string category = "test";
        private const string reviewContent = "testContent";
        private const string gameTitle = "title";

        [TestFixtureSetUp]
        public void PlanetAreaControllerTestsSetup()
        {
            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(ReviewsController).Assembly);

            var reviewsServiceMock = new Mock<IReviewsService>();
            reviewsServiceMock
                .Setup(x => x.GetById(reviewId))
                .Returns(new Review()
                {
                    Content = reviewContent,
                    Category = new Category() { Name = "Some" }
                });

            reviewsServiceMock
                .Setup(x => x.GetByPageAndCategory(category, page))
                .Returns(new List<Review>()
                {
                    new Review
                    {
                        Content = reviewContent,
                        Category = new Category() { Name = "Some" },
                        GameTitle = gameTitle
                    },
                    new Review
                    {
                        Content = reviewContent,
                        Category = new Category() { Name = "Some" },
                        GameTitle = gameTitle
                    }
                }.AsQueryable());

            var categoriesServiceMock = new Mock<ICategoriesService>();
            
            reviewsController = new ReviewsController(reviewsServiceMock.Object, categoriesServiceMock.Object);
        }

        [Test]
        public void TestGetReviewByIdWithValidId()
        {
            reviewsController
                .WithCallTo(x => x.Details(reviewId))
                .ShouldRenderView("Details")
                .WithModel<ReviewViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(reviewContent, viewModel.Content);
                    }
                )
                .AndNoModelErrors();
        }

        [Test]
        public void TestGetReviewByIdWithNullIdShouldReturnBadRequest()
        {
            reviewsController
                .WithCallTo(x => x.Details(null))
                .ShouldGiveHttpStatus(400);
        }

        [Test]
        public void TestGetReviewByIdWithInvalidIdShouldReturnNotFound()
        {
            reviewsController
                .WithCallTo(x => x.Details(12))
                .ShouldGiveHttpStatus(404);
        }
    }
}

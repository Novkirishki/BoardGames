namespace BoardGames.Web.Controllers.Tests
{
    using Areas.Private.Controllers;
    using Areas.Private.Models;
    using Data.Models;
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class PrivateCommentsControllerTests
    {
        private CommentsController commentsController;
        private const int tutorialId = 2;
        private const int pages = 7;
        private const int page = 3;
        private const string content = "content";

        [TestFixtureSetUp]
        public void PlanetAreaControllerTestsSetup()
        {
            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(CommentsController).Assembly);

            var commentsServiceMock = new Mock<ICommentsService>();
            commentsServiceMock
                .Setup(x => x.GetPagesCount(tutorialId))
                .Returns(pages);

            commentsServiceMock
                .Setup(x => x.GetByPage(tutorialId, page))
                .Returns(new List<Comment>()
                {
                    new Comment
                    {
                        Content = content,
                        Tutorial = new Tutorial { Title = "" },
                        Author = new User()
                    },
                    new Comment
                    {
                        Content = content,
                        Tutorial = new Tutorial { Title = "" },                      
                        Author = new User()
                    }
                }.AsQueryable());

            commentsController = new CommentsController(commentsServiceMock.Object);
        }

        [Test]
        public void TestGetReviewByIdWithValidData()
        {
            commentsController
                .WithCallTo(x => x.GetByPage(2, 3))
                .ShouldRenderPartialView("_CommentsPartial")
                .WithModel<CommentsViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(pages, viewModel.Pages);
                        Assert.AreEqual(content, viewModel.Comments.First().Content);
                        Assert.AreEqual(2, viewModel.Comments.Count());
                    }
                )
                .AndNoModelErrors();
        }

        [Test]
        public void TestGetReviewByIdWithInvalidData()
        {
            commentsController
                .WithCallTo(x => x.GetByPage(1, 12))
                .ShouldRenderPartialView("_CommentsPartial")
                .WithModel<CommentsViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(0, viewModel.Pages);
                        Assert.AreEqual(0, viewModel.Comments.Count());
                    }
                )
                .AndNoModelErrors();
        }
    }
}

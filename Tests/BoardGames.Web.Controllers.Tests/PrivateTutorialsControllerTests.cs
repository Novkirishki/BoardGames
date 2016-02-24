namespace BoardGames.Web.Controllers.Tests
{
    using Areas.Admin.Models;
    using Areas.Private.Controllers;
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Contracts;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class PrivateTutorialsControllerTests
    {
        private TutorialsController tutorialsController;
        private const int id = 12;

        [TestFixtureSetUp]
        public void PlanetAreaControllerTestsSetup()
        {
            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(TutorialsController).Assembly);

            var tutorialsServiceMock = new Mock<ITutorialsService>();
            tutorialsServiceMock
                .Setup(x => x.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), null))
                .Returns(id);

            var likesServiceMock = new Mock<ILikesService>();

            tutorialsController = new TutorialsController(tutorialsServiceMock.Object, likesServiceMock.Object);
        }

        [Test]
        public void TestTutorialsCreatePage()
        {
            tutorialsController
                .WithCallTo(x => x.Create())
                .ShouldRenderView("Create")
                .WithModel<TutorialViewModel>()
                .AndNoModelErrors();
        }
    }
}

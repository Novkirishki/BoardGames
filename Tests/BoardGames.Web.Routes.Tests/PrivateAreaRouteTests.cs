namespace BoardGames.Web.Routes.Tests
{
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using System.Web.Mvc;
    using System.Net.Http;
    using Areas.Private;
    using Areas.Private.Controllers;

    [TestFixture]
    public class PrivateAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var areaReg = new PrivateAreaRegistration();
            var areaContext = new AreaRegistrationContext(areaReg.AreaName, RouteTable.Routes);
            areaReg.RegisterArea(areaContext);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [TestFixtureTearDown]
        public void RouteCollectionDestroy()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void TestTutorialsBaseRouteWithDefaultPage()
        {
            var url = "/Private/Tutorials?page=1";
            this.routeCollection.ShouldMap(url).To<TutorialsController>(HttpMethod.Get, c => c.Index(1));
        }

        [Test]
        public void TestTutorialsBaseRouteWithCustomPage()
        {
            var url = "/Private/Tutorials?page=12";
            this.routeCollection.ShouldMap(url).To<TutorialsController>(HttpMethod.Get, c => c.Index(12));
        }

        [Test]
        public void TestTutorialsBaseRouteWithInvalidQueryParam()
        {
            var url = "/Private/Tutorials?page=1&category=some";
            this.routeCollection.ShouldMap(url).To<TutorialsController>(HttpMethod.Get, c => c.Index(1));
        }

        [Test]
        public void TestTutorialsDetailsWithoutdId()
        {
            var url = "/Private/Tutorials/Details";
            this.routeCollection.ShouldMap(url).To<TutorialsController>(HttpMethod.Get, c => c.Details(null));
        }

        [Test]
        public void TestTutorialsDetailsWithId()
        {
            var url = "/Private/Tutorials/Details/15";
            this.routeCollection.ShouldMap(url).To<TutorialsController>(HttpMethod.Get, c => c.Details(15));
        }

        [Test]
        public void TestTutorialsDetailsWithInvalidQueryParam()
        {
            var url = "/Private/Tutorials/Details/15?page=18";
            this.routeCollection.ShouldMap(url).To<TutorialsController>(HttpMethod.Get, c => c.Details(15));
        }

        [Test]
        public void TestTutorialsCreatePageRoute()
        {
            var url = "/Private/Tutorials/Create";
            this.routeCollection.ShouldMap(url).To<TutorialsController>(HttpMethod.Get, c => c.Create());
        }

        [Test]
        public void TestTutorialsCreate()
        {
            var url = "/Private/Tutorials/Create";
            this.routeCollection.ShouldMap(url).To<TutorialsController>(HttpMethod.Get, c => c.Create());
        }

        [Test]
        public void TestCommentsGetRoute()
        {
            var url = "/Private/Comments/GetByPage?page=4&tutorialId=12";
            this.routeCollection.ShouldMap(url).To<CommentsController>(HttpMethod.Get, c => c.GetByPage(12,4));
        }

        [Test]
        public void TestCommentsGetRouteWithInvalidQueryParam()
        {
            var url = "/Private/Comments/GetByPage?page=4&category=test&tutorialId=12";
            this.routeCollection.ShouldMap(url).To<CommentsController>(HttpMethod.Get, c => c.GetByPage(12, 4));
        }
    }
}

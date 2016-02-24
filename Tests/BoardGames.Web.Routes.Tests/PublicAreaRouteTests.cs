namespace BoardGames.Web.Routes.Tests
{
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using Areas.Public;
    using System.Web.Mvc;
    using Areas.Public.Controllers;
    using System.Net.Http;

    [TestFixture]
    public class PublicAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var areaReg = new PublicAreaRegistration();
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
        public void TestReviewsBaseRouteWithDefaultCategoryAndPage()
        {
            var url = "/Public/Reviews?page=1";
            this.routeCollection.ShouldMap(url).To<ReviewsController>(HttpMethod.Get, c => c.Index(null,1));
        }

        [Test]
        public void TestReviewsBaseRouteWithCustomCategoryAndPage()
        {
            var url = "/Public/Reviews?page=11&category=someCategory";
            this.routeCollection.ShouldMap(url).To<ReviewsController>(HttpMethod.Get, c => c.Index("someCategory", 11));
        }

        [Test]
        public void TestReviewsBaseRouteWithInvalidQueryParam()
        {
            var url = "/Public/Reviews?page=11&category=someCategory&test=testing";
            this.routeCollection.ShouldMap(url).To<ReviewsController>(HttpMethod.Get, c => c.Index("someCategory", 11));
        }

        [Test]
        public void TestReviewsDetailsRouteWithoutId()
        {
            var url = "/Public/Reviews/Details";
            this.routeCollection.ShouldMap(url).To<ReviewsController>(HttpMethod.Get, c => c.Details(null));
        }

        [Test]
        public void TestReviewsDetailsRouteWithId()
        {
            var url = "/Public/Reviews/Details/14";
            this.routeCollection.ShouldMap(url).To<ReviewsController>(HttpMethod.Get, c => c.Details(14));
        }

        [Test]
        public void TestReviewsDetailsWithInvalidQueryParam()
        {
            var url = "/Public/Reviews/Details/14?category=test";
            this.routeCollection.ShouldMap(url).To<ReviewsController>(HttpMethod.Get, c => c.Details(14));
        }
    }
}

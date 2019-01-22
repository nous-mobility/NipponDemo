using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace LifeBenefits.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void ValidateLoginScreenLabels()
        {
            Assert.NotNull(app.Query(c => c.Marked("LblFindProvider")).FirstOrDefault());
            // Test if the the element contains proper value
            Assert.AreEqual("Find a Provider", app.Query(c => c.Marked("LblFindProvider")).First().Text);

            Assert.NotNull(app.Query(c => c.Marked("LblContactUs")).FirstOrDefault());
            // Test the the element contains the proper value
            Assert.AreEqual("Contact Us", app.Query(c => c.Marked("LblContactUs")).First().Text);

            Assert.NotNull(app.Query(c => c.Marked("LblLogin")).FirstOrDefault());
            // Test if the the element contains proper value
            Assert.AreEqual("Login", app.Query(c => c.Marked("LblLogin")).First().Text);
        }
    }
}

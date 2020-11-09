using NUnit.Framework;

namespace TestProject1.Tests
{
    public class TestBase
    {
        protected ApplicationManager App;

        [SetUp]
        public void SetupTest()
        {
            App = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            ApplicationManager.Stop();
        }
    }
}
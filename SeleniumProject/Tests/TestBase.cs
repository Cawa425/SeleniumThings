using NUnit.Framework;

namespace SeleniumProject.Tests
{
    public class TestBase
    {
        protected ApplicationManager App;

        [SetUp]
        public void SetupTest()
        {
            App = ApplicationManager.GetInstance();
        }
    }
}
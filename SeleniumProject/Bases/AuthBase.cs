using NUnit.Framework;
using SeleniumProject.Tests;

namespace SeleniumProject.Bases
{
    public class AuthBase:TestBase
    {
        [SetUp]
        public new void SetupTest()
        {
            App = ApplicationManager.GetInstance();
            App.Navigation.OpenMainPage();
        }

    }
}
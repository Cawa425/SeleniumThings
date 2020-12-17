using NUnit.Framework;
using SeleniumProject.Bases;
using SeleniumProject.Models;

namespace SeleniumProject.Tests
{    
    [TestFixture]
    public class LoginTests : AuthBase
    {
        [Test]
        public void LoginWithValidData()
        {
            if(App.Auth.IsLoggedIn())App.Auth.Logout();
            App.Navigation.OpenMainPage();
            App.Auth.Login(new AccountData(Settings.Login,Settings.Password));
        }
        [Test]
        public void LoginWithInvalidData()
        {
            if(App.Auth.IsLoggedIn())App.Auth.Logout();
            App.Navigation.OpenMainPage();
            App.Auth.Login(new AccountData(Settings.Login,"12345"));
            
        }
    }
}
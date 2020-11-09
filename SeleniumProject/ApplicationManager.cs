using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.Helpers;

namespace SeleniumProject
{
    public class ApplicationManager
    {
        private readonly string _baseUrl;
        private StringBuilder _verificationErrors;

        public ApplicationManager()
        {
            Driver = new ChromeDriver(@"C:\Users\cfifr\OneDrive\Рабочий стол\driver");
            Driver.Manage().Window.Maximize();
            _baseUrl = "https://www.google.com/";
            _verificationErrors = new StringBuilder();
            Auth = new LoginHelper(this);
            Navigation = new NavigationHelper(this, _baseUrl);
            Mail = new MailHelper(this);
        }


        public static IWebDriver Driver { get; private set; }

        public LoginHelper Auth { get; }

        public NavigationHelper Navigation { get; }

        public MailHelper Mail { get; }

        public static void Stop()
        {
            Driver.Quit();
        }
    }
}
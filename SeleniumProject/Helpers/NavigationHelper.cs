namespace SeleniumProject.Helpers
{
    public class NavigationHelper: HelperBase
    {
        private string baseURL;
        public void OpenMainPage()
        {
           driver.Navigate().GoToUrl("https://www.mail.ru/");
        }
        public void OpenMailsPage()
        {
            driver.Navigate().GoToUrl("https://www.mail.ru/inbox");
        }

        public void OpenSendMails()
        {
            driver.Navigate().GoToUrl("https://e.mail.ru/sent/");
        }

        public void OpenDrafts()
        {
            driver.Navigate().GoToUrl("https://e.mail.ru/drafts/");
        }
        public NavigationHelper(ApplicationManager manager, string baseUrl)
            : base(manager)
        {
            baseURL = baseUrl;
        }
    }
}
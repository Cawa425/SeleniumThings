namespace TestProject1.Helpers
{
    public class NavigationHelper: HelperBase
    {
        private string baseURL;
        public void OpenHomePage()
        {
           driver.Navigate().GoToUrl("https://www.mail.ru/");
        }
        public NavigationHelper(ApplicationManager manager, string baseUrl)
            : base(manager)
        {
            baseURL = baseUrl;
        }
    }
}
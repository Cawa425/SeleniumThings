using OpenQA.Selenium;

namespace TestProject1.Helpers
{
    public abstract class HelperBase
    {
        protected readonly IWebDriver driver;
        public IJavaScriptExecutor js;
        private bool _acceptNextAlert = true;
        private ApplicationManager _manager;

        protected HelperBase(ApplicationManager manager)
        {
            _manager = manager;
            driver = ApplicationManager.Driver;
            js = (IJavaScriptExecutor)driver;
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                var alertText = alert.Text;
                if (_acceptNextAlert) alert.Accept();
                else alert.Dismiss();
                return alertText;
            }
            finally
            {
                _acceptNextAlert = true;
            }
        }
    }
}
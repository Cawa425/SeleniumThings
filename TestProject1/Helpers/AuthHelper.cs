using System.Threading;
using OpenQA.Selenium;
using TestProject1.Models;

namespace TestProject1.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData user)
        {
            
            Forms("mailbox:login-input", user.Username);
            Thread.Sleep(5000);
            Forms("mailbox:password-input", user.Password);
        }

        public void Logout()
        {
        }

        private void Forms(string name, string text)
        {
            driver.FindElement(By.Id(name)).Clear();
            driver.FindElement(By.Id(name)).SendKeys(text);
            driver.FindElement(By.XPath("//input[@value='Ввести пароль']")).Click();
        }
    }
}
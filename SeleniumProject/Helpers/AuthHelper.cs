﻿using System.Threading;
using OpenQA.Selenium;
using SeleniumProject.Models;

namespace SeleniumProject.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public bool IsLoggedIn()
        {
            return driver.FindElement(By.Id("PH_logoutLink"))==null;
        }
        

        public void Login(AccountData user)
        {

            Forms("mailbox:login-input", user.Username);
            Thread.Sleep(5000);
            Forms("mailbox:password-input", user.Password);
        }

        public void Logout()
        {
            driver.FindElement(By.Id("PH_logoutLink")).Click();
        }

        private void Forms(string name, string text)
        {
            driver.FindElement(By.Id(name)).Clear();
            driver.FindElement(By.Id(name)).SendKeys(text);
            driver.FindElement(By.XPath("//input[@value='Ввести пароль']")).Click();
        }
    }
}
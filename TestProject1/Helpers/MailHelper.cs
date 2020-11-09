using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using TestProject1.Models;

namespace TestProject1.Helpers
{
    public class MailHelper : HelperBase

    {
        public MailHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void SendMail(MailData mailData)
        {
            driver.Navigate().GoToUrl("https://e.mail.ru/inbox/");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("span.compose-button__txt")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("div.input--3slxg")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(//input[@value=''])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@value=''])[2]")).SendKeys("kostan-sasha@bk.ru");
            driver.FindElement(By.XPath("(//input[@value=''])[2]")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//div[5]/div/div/div[2]/div/div")).Click();
            driver.FindElement(By.XPath("//div[5]/div/div/div[2]/div")).SendKeys(mailData.Text);
            driver.FindElement(By.XPath("//div[2]/div/span/span/span")).Click();
        }

        public void EditLast()
        {
            driver.Navigate().GoToUrl("https://e.mail.ru/drafts/");
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".nav__item:nth-child(3) .nav__folder-name__txt")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".llc:nth-child(3) .llc__item_correspondent")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Name("Subject")).Click();
            driver.FindElement(By.Name("Subject")).SendKeys("Editing");
            driver.FindElement(By.CssSelector(".button2:nth-child(2) .button2__txt")).Click();
        }
    }
}
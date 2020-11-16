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
using SeleniumProject.Models;

namespace SeleniumProject.Helpers
{
    public class MailHelper : HelperBase

    {
        public MailHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void SendMail(MailData mailData)
        {
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("span.compose-button__txt")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("div.input--3slxg")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("(//input[@value=''])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@value=''])[2]")).SendKeys("kostan-sasha@bk.ru");
            driver.FindElement(By.XPath("(//input[@value=''])[2]")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//div[5]/div/div/div[2]/div/div")).Click();
            driver.FindElement(By.XPath("//div[5]/div/div/div[2]/div")).SendKeys(mailData.Text);
            driver.FindElement(By.XPath("//div[2]/div/span/span/span")).Click();
        }

        public void EditLast()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".nav__item:nth-child(3) .nav__folder-name__txt")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".llc:nth-child(3) .llc__item_correspondent")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Subject")).Click();
            driver.FindElement(By.Name("Subject")).SendKeys("Editing");
            driver.FindElement(By.CssSelector(".button2:nth-child(2) .button2__txt")).Click();
        }

        public void DeleteLast()
        {
            driver.FindElement(By.CssSelector(".button2_select-all > .button2__wrapper")).Click();
            Thread.Sleep(1000);
            foreach (var findElement in driver.FindElements(By.CssSelector(".ll-av__checkbox")).Skip(1))
            {
                findElement.Click();
            }
            driver.FindElement(By.CssSelector(".button2_delete > .button2__wrapper")).Click();
        }

        public MailData GetLastRecievedMail()
        {
            var adress = driver.FindElement(By.CssSelector(".ll-crpt")).GetAttribute("title");
            var content = driver.FindElement(By.CssSelector(".ll-sp__normal")).Text;
            return new MailData( adress,content);
        }

        public MailData SelectLastSendMail()
        {
            return GetLastRecievedMail();
        }

        public MailData OpenSendRecievedMail()
        {
            return SelectLastSendMail();
        }
    }
}
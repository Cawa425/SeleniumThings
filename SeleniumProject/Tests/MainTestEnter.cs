using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml.Serialization;
using NUnit.Framework;
using SeleniumProject.Bases;
using SeleniumProject.Helpers;
using SeleniumProject.Models;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class Test : TestBase
    {
        private static IEnumerable<MailData> MailDataFromXmlFile()
        {
            return (List<MailData>) new XmlSerializer(typeof(List<MailData>)).Deserialize(
                new StreamReader(
                    @"C:\Users\cfifr\RiderProjects\TestProject1\ConsoleApp1\bin\Release\netcoreapp3.1\Mails.xml"));
        }

        [Test]
        public void A_Login()
        {
            App.Navigation.OpenMainPage();
            App.Auth.Login(new AccountData(Settings.Login,Settings.Password));
        }

        [Test, TestCaseSource(nameof(MailDataFromXmlFile))]
        public void T_2SendMails(MailData mailData)
        {
            App.Navigation.OpenMailsPage();
            Thread.Sleep(2000);
            App.Mail.SendMail(new MailData(mailData.Adress, mailData.Text));
        }

        [Test]
        public void T_3EditLastDraftTheme()
        {
            Thread.Sleep(2000);
            App.Navigation.OpenDrafts();
            Thread.Sleep(2000);
            App.Mail.EditLast();
        }

        [Test]
        public void T_4LastSendMailValidation()
        {
            Thread.Sleep(2000);
            App.Navigation.OpenSendMails();
            Thread.Sleep(2000);
            var last = App.Mail.SelectLastSendMail();
            var temp = new MailData("kostan-sasha@bk.ru", "bruh");
            Assert.True(last.Adress.Contains(temp.Adress) && last.Text.Contains(temp.Text));
        }

        [Test]
        public void T_5Delete()
        {
            Thread.Sleep(2000);
            App.Navigation.OpenDrafts();
            Thread.Sleep(2000);
            App.Mail.DeleteLast();
        }

        [Test]
        public void Z_LogoutTest()
        {
            App.Auth.Logout();
        }
    }
}
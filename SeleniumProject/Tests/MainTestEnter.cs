using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Threading;
using NUnit.Framework;
using SeleniumProject.Helpers;
using SeleniumProject.Models;

namespace SeleniumProject.Tests
{
    [TestFixture]
    
    public class Test : TestBase
    {
        [Test]
        

        public void A_Login()
        {
            App.Navigation.OpenMainPage();
            App.Auth.Login(new AccountData("y_sanek@bk.ru", "42544321cawa"));
        }

        [Test]
        public void T_2SendMail()
        {
            App.Navigation.OpenMailsPage();
            Thread.Sleep(2000);
            App.Mail.SendMail(new MailData("kostan-sasha@bk.ru", "bruh"));
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
            var temp = new MailData("kostan-sasha@bk.ru","bruh");
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
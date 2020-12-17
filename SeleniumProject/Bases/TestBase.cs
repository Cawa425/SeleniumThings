using System;
using System.Text;
using NUnit.Framework;
using SeleniumProject.Models;

namespace SeleniumProject.Bases
{
    public class TestBase
    {
        protected ApplicationManager App;

        public static string GenerateRandomString(int lenght)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZasdfghjklqwertyuiopzxcvbnm1234567890".ToCharArray();
            var rng  =  new Random();
            var str = new StringBuilder();
            for (var i = 0; i < lenght; i++) str.Append(chars[rng.Next(0, chars.Length - 1)]);
            return str.ToString();
        }


        [SetUp]
        public void SetupTest()
        {
            App = ApplicationManager.GetInstance();
        }
    }
}
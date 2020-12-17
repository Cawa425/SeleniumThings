using System;
using System.Xml;

namespace SeleniumProject
{
    public static class Settings
    {
        private const string File = @"C:\Users\cfifr\RiderProjects\TestProject1\SeleniumProject\Settings.xml";
        private static string _baseUrl;
        private static string _login;
        private static string _password;
        private static readonly XmlDocument Document;

        static Settings()
        {
            if (!System.IO.File.Exists(File))
            {
                throw new Exception("Problem: settings file not found: " + File);
            }

            Document = new XmlDocument();
            Document.Load(File);
        }

        public static string BaseURL
        {
            get
            {
                if (_baseUrl == null)
                {
                    XmlNode node = Document.DocumentElement.SelectSingleNode("BaseUrl");
                    _baseUrl = node.InnerText;
                }

                return _baseUrl;
            }
        }

        public static string Login
        {
            get
            {
                if (_login == null)
                {
                    XmlNode node = Document.DocumentElement.SelectSingleNode("Login");
                   _login = node.InnerText;
                }
                return _login;
            }
        }

        public static string Password
        {
            get
            {
                if (_password == null)
                {
                    XmlNode node = Document.DocumentElement.SelectSingleNode("Password");
                    _password = node.InnerText;
                }
                return _password;
            }
        }
    }
}
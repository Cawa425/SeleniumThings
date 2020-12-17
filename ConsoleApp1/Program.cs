using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using SeleniumProject.Bases;
using SeleniumProject.Models;

namespace ConsoleApp1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            AutoltScipt.AutoScriptMain();
            //TestsStart(args);
        }

        private static void TestsStart(string[] args)
        {
            var type = args[0];
            var count = Convert.ToInt32(args[1]);
            var filename = args[2];
            //var format = args[3];
            if (type == "Mails") GenerateForMails(count, filename);
            else Console.Out.Write("Unrecognized type of data" + type);
        }

        private static void GenerateForMails(int count, string filename)
        {
            var mails = new List<MailData>();
            for (var i = 0; i < count; i++)
                mails.Add(new MailData
                {
                    Adress = TestBase.GenerateRandomString(10) + "@bk.ru",
                    Text = TestBase.GenerateRandomString(10)
                });

            var writer = new StreamWriter(filename);
            new XmlSerializer(typeof(List<MailData>)).Serialize(writer, mails);
            writer.Close();
        }
    }
}
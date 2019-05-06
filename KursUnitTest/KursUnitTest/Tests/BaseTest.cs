using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using KursUnitTest.Helpers;
using System.Text;

namespace KursUnitTest
{

    //[TestFixture]
    public class BaseTest
    {
        protected ApplicationManager app;
        /// <summary>
        /// функция выполняется перед каждым тестом
        /// </summary>
        [SetUp]
        public void SetUpApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GetRandomDay()
        {
            int l = rnd.Next(0, 32);
            if (l == 0)
            {
                return "-";
            }
            return l.ToString();
        }

        public static string[] ListMonth = new  string[] { "-", "January", };

        public static string GetRandomYear()
        {

            if (rnd.Next(0, 2) == 0)
            {
                return rnd.Next(1890, 2100).ToString();
            }
            else
            {
                return GenerateRandomString(4);
            }
        }


        public static string GetRandomMonth()
        {

            return ListMonth[rnd.Next(0, ListMonth.Length)];
        }

        public static string GenerateRandomString(int max)
        {
            int l = rnd.Next(0, max+1);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(rnd.Next(33, 234)));
            }
            return builder.ToString();
        }

        /// <summary>
        /// функция выполняется перед каждым тестом
        /// </summary>
        [OneTimeSetUp]
        public void OnOneTimeSetUp()
        {
        }

        /// <summary>
        /// функция выполняется после каждого теста
        /// </summary>
        [TearDown]
        public void TearDown()
        {
        }

        /// <summary>
        /// функция выполняется после каждого теста
        /// </summary>
        [OneTimeTearDown]
        public void OnOneTimeTearDown()
        {
        }
    }
}

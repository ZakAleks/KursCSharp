using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using KursUnitTest.app;

namespace KursUnitTest
{

    //[TestFixture]
    public class BaseTest
    {
        public Application app;

        /// <summary>
        /// функция выполняется перед каждым тестом
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            app = new Application();
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
            app.Quit();
            app = null;
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

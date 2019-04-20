using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    class Zadanie1 : BaseTest
    {

        public string Url = "http://localhost/addressbook/";



        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.CssSelector("input[name='user']")).Clear();
            driver.FindElement(By.CssSelector("input[name='user']")).SendKeys("admin");
            driver.FindElement(By.CssSelector("input[name='pass']")).Clear();
            driver.FindElement(By.CssSelector("input[name='pass']")).SendKeys("secret");
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();

            driver.FindElement(By.CssSelector("a[href$='group.php']")).Click();
            driver.FindElement(By.CssSelector("input[name='new']")).Click();


            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys("Group Name");
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).SendKeys("Group Header");
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).SendKeys("Group Footer");
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();

            driver.FindElement(By.CssSelector("div[class='msgbox'] a[href$='group.php']")).Click();

            driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();

        }
    }
}

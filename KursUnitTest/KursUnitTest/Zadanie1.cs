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

        protected string Url = "http://localhost/addressbook/";



        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccauntData("admin","secret"));
            GoToGroupsPage();
            initGroupCreation();
            FillGroupForm(new GroupData("Group Name","Group Header","Group Footer"));
            SubmitGroupCreation();
            ReturnsToGroupPage();
            LogOut();
        }

        private void LogOut()
        {
            driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();
        }

        private void ReturnsToGroupPage()
        {
            driver.FindElement(By.CssSelector("div[class='msgbox'] a[href$='group.php']")).Click();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
        }

        private void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys(group.GroupName);
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).SendKeys(group.GroupHeader);
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).SendKeys(group.GroupFooter);

        }

        private void initGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='new']")).Click();
        }

        private void GoToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href$='group.php']")).Click();
        }

        private void Login(AccauntData accaunt)
        {
            driver.FindElement(By.CssSelector("input[name='user']")).Clear();
            driver.FindElement(By.CssSelector("input[name='user']")).SendKeys(accaunt.Username);
            driver.FindElement(By.CssSelector("input[name='pass']")).Clear();
            driver.FindElement(By.CssSelector("input[name='pass']")).SendKeys(accaunt.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}

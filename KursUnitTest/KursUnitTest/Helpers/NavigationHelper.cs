using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    internal class NavigationHelper : BaseHelper
    {
        private string url;

        public NavigationHelper(ApplicationManager Manager, string Url) : base(Manager)
        {
            url = Url;
        }


        public NavigationHelper GoToAddContactPage()
        {
            driver.FindElement(By.CssSelector("a[href$='edit.php']")).Click();
            return this;
        }

        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href$='group.php']")).Click();
            return this;
        }

        public NavigationHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
    }
}

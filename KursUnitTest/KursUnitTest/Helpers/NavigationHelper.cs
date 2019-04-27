using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    public class NavigationHelper : BaseHelper
    {
        private string url;

        public NavigationHelper(ApplicationManager Manager, string Url) : base(Manager)
        {
            url = Url;
        }


        public NavigationHelper GoToAddContactPage()
        {
            if (driver.Url == url + "edit.php" && IsElementPresent(By.CssSelector("[name='submit']")))
            {
                return this;
            }
            else
            {
                driver.FindElement(By.CssSelector("a[href$='edit.php']")).Click();
            }

            return this;
        }

        public NavigationHelper GoToGroupsPage()
        {
            if (driver.Url == url + "group.php" && IsElementPresent(By.CssSelector("[name='new']")))
            {
                return this;
            }
            else
            {
                driver.FindElement(By.CssSelector("a[href$='group.php']")).Click();
            }
            return this;
        }

        public NavigationHelper GoToHomePage()
        {
            if (driver.Url == url && IsElementPresent(By.CssSelector("[name='searchstring']")))
            {
                return this;
            }
            else
            {
                driver.FindElement(By.LinkText("home")).Click();
            }
            
            return this;
        }

        public NavigationHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
    }
}

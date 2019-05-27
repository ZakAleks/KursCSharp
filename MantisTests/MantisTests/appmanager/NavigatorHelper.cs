using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MantisTests
{
    public class NavigatorHelper : BaseHelper
    {
        public NavigatorHelper(ApplicationManager Manager) : base(Manager)
        {
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.21.0/login_page.php";
        }

        public void OpenControlPage()
        {
            driver.FindElement(By.CssSelector("i.fa-gears")).Click();
        }

        internal void GoToProjectsPage()
        {
            OpenControlPage();
            OpenControlProectPage();
        }

        public void OpenControlProectPage()
        {
            driver.FindElement(By.CssSelector("a[href$='manage_proj_page.php']")).Click();
        }
    }
}

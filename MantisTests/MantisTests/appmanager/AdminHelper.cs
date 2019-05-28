using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MantisTests
{
    public class AdminHelper : BaseHelper
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager Manager, string baseUrl) : base(Manager)
        {
            this.baseUrl = baseUrl;
        }

        public List<AccauntData> GetAllAccaunts()
        {

            return null;
        }

        public void DeletAccaunt(AccauntData accaunt)
        {
            var driver = OpenAppAndLogin();
            driver.Url = baseUrl + "manage_user_edit_page.php?user_id="+ accaunt.Id;
            driver.FindElement(By.CssSelector("form[id='manage-user-delete-form'] span input")).Click();
            driver.FindElement(By.CssSelector("form input.btn-primary")).Click();
        }

        internal List<AccauntData> GetAllAccaunt()
        {
            var driver = OpenAppAndLogin();
            driver.Url = baseUrl + "manage_user_page.php";

            List<AccauntData> accaunts = new List<AccauntData>();
            var traccaunts = driver.FindElements(By.CssSelector("table tbody tr"));
            foreach (var tr in traccaunts)
            {
                AccauntData accaunt = new AccauntData();
                var nameLink = tr.FindElement(By.TagName("a"));
                accaunt.Username = nameLink.Text;
                var href = nameLink.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                accaunt.Id = m.Value;
                accaunts.Add(accaunt);
            }
            return accaunts;
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "login_page.php";

            driver.FindElement(By.CssSelector("input[id='username']")).SendKeys("administrator");
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
            driver.FindElement(By.CssSelector("input[id='password']")).SendKeys("root");
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
            return driver;

        }
    }
}

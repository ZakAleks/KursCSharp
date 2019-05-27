using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests
{
    public class LoginHelper : BaseHelper
    {

        public LoginHelper(ApplicationManager Manager) : base(Manager)
        {
        }

        public void Login(AccauntData accaunt)
        {
            manager.Navigator.OpenMainPage();

            if (IsLoggedIn())
            {
                if (IsLoggedIn(accaunt))
                {
                    return;
                }
                LogOut();
            }

            driver.FindElement(By.CssSelector("input[id='username']")).SendKeys(accaunt.Username);
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
            driver.FindElement(By.CssSelector("input[id='password']")).SendKeys(accaunt.Password);
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
        }

        public bool IsLoggedIn(AccauntData accaunt)
        {
            return IsLoggedIn() && GetLoggedUserName() == accaunt.Username;
        }

        public string GetLoggedUserName()
        {
            return driver.FindElement(By.CssSelector("span[class='user-info']")).Text;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("input[name='bug_id']"));
        }

        public void LogOut()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span[class='user-info']")).Click();
                driver.FindElement(By.CssSelector("i.fa-sign-out")).Click();
            }
        }
    }
}

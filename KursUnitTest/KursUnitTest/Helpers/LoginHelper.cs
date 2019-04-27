using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    public class LoginHelper : BaseHelper
    {

        public LoginHelper(ApplicationManager Manager) : base(Manager)
        {
        }
        public void Login(AccauntData accaunt)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(accaunt))
                {
                    return;
                }
                LogOut();
            }
            Type(By.CssSelector("input[name='user']"), accaunt.Username);
            Type(By.CssSelector("input[name='pass']"), accaunt.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }

        public bool IsLoggedIn(AccauntData accaunt)
        {
            return IsLoggedIn() && driver.FindElement(By.CssSelector("[name='logout']")).FindElement(By.CssSelector("b")).Text == "("+ accaunt.Username + ")";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("[name='logout']"));
        }

        public void LogOut()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();
            }
        }
    }
}

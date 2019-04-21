using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    internal class LoginHelper : BaseHelper
    {

        public LoginHelper(ApplicationManager Manager) : base(Manager)
        {
        }
        public void Login(AccauntData accaunt)
        {
            driver.FindElement(By.CssSelector("input[name='user']")).Clear();
            driver.FindElement(By.CssSelector("input[name='user']")).SendKeys(accaunt.Username);
            driver.FindElement(By.CssSelector("input[name='pass']")).Clear();
            driver.FindElement(By.CssSelector("input[name='pass']")).SendKeys(accaunt.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }

        public void LogOut()
        {
            driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();
        }
    }
}

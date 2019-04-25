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

            Type(By.CssSelector("input[name='user']"), accaunt.Username);
            Type(By.CssSelector("input[name='pass']"), accaunt.Password);

            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }

        public void LogOut()
        {
            driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();
        }
    }
}

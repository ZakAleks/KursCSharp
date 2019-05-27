using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MantisTests
{
    public class RegistrationHelper : BaseHelper
    {
        public RegistrationHelper(ApplicationManager Manager) : base(Manager)
        {
        }

        public void Register(AccauntData accaunt)
        {
            manager.Navigator.OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(accaunt);
            SubminRegistration();

            string url = GetConfirmationUrl(accaunt);
            FillPasswordForm(url, accaunt);
            SubminPasswordForm();

        }

        private string GetConfirmationUrl(AccauntData accaunt)
        {
            var text = manager.Mail.GetLastMail(accaunt);
            var match = Regex.Match(text, @"http://\S*");
            return match.Value;
        }

        private void FillPasswordForm(string url, AccauntData accaunt)
        {
            driver.Url = url;
            driver.FindElement(By.CssSelector("input[id='password']")).SendKeys(accaunt.Password);
            driver.FindElement(By.CssSelector("input[id='password-confirm']")).SendKeys(accaunt.Password);
        }

        private void SubminPasswordForm()
        {
            driver.FindElement(By.CssSelector("button.btn-success")).Click();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a[href*='signup_page.php']")).Click();
        }

        private void SubminRegistration()
        {
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
        }

        private void FillRegistrationForm(AccauntData accaunt)
        {
            driver.FindElement(By.CssSelector("input[id='username']")).SendKeys(accaunt.Username);
            driver.FindElement(By.CssSelector("input[id='email-field']")).SendKeys(accaunt.Email);
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(accaunt);
            SubminRegistration();
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

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.21.0/login_page.php";
        }
    }
}

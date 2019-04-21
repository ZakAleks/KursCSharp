using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace KursUnitTest
{

    //[TestFixture]
    internal class BaseTest
    {

        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected string Url = "http://localhost/addressbook/";

        /// <summary>
        /// функция выполняется перед каждым тестом
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        /// <summary>
        /// функция выполняется перед каждым тестом
        /// </summary>
        [OneTimeSetUp]
        public void OnOneTimeSetUp()
        {
        }

        /// <summary>
        /// функция выполняется после каждого теста
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        /// <summary>
        /// функция выполняется после каждого теста
        /// </summary>
        [OneTimeTearDown]
        public void OnOneTimeTearDown()
        {
        }

        protected void LogOut()
        {
            driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();
        }

        protected void ReturnsToGroupPage()
        {
            driver.FindElement(By.CssSelector("div[class='msgbox'] a[href$='group.php']")).Click();
        }

        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys(group.GroupName);
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).SendKeys(group.GroupHeader);
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).SendKeys(group.GroupFooter);

        }

        protected void initGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='new']")).Click();
        }

        protected void GoToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href$='group.php']")).Click();
        }

        protected void Login(AccauntData accaunt)
        {
            driver.FindElement(By.CssSelector("input[name='user']")).Clear();
            driver.FindElement(By.CssSelector("input[name='user']")).SendKeys(accaunt.Username);
            driver.FindElement(By.CssSelector("input[name='pass']")).Clear();
            driver.FindElement(By.CssSelector("input[name='pass']")).SendKeys(accaunt.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }

        protected void OpenHomePage(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }

        protected void FillAdressEntryForm(AddressBookEntryData adressEntry)
        {
            driver.FindElement(By.CssSelector("a[href$='edit.php']")).Click();
            driver.FindElement(By.CssSelector("input[name='firstname']")).Clear();
            driver.FindElement(By.CssSelector("input[name='firstname']")).SendKeys(adressEntry.FirstName);
            driver.FindElement(By.CssSelector("input[name='middlename']")).Clear();
            driver.FindElement(By.CssSelector("input[name='middlename']")).SendKeys(adressEntry.MiddleName);
            driver.FindElement(By.CssSelector("input[name='lastname']")).Clear();
            driver.FindElement(By.CssSelector("input[name='lastname']")).SendKeys(adressEntry.LastName);
            driver.FindElement(By.CssSelector("input[name='nickname']")).Clear();
            driver.FindElement(By.CssSelector("input[name='nickname']")).SendKeys(adressEntry.Nickname);
            driver.FindElement(By.CssSelector("input[name='title']")).Clear();
            driver.FindElement(By.CssSelector("input[name='title']")).SendKeys(adressEntry.Title);
            driver.FindElement(By.CssSelector("input[name='company']")).Clear();
            driver.FindElement(By.CssSelector("input[name='company']")).SendKeys(adressEntry.Company);
            driver.FindElement(By.CssSelector("textarea[name='address']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address']")).SendKeys(adressEntry.Address);
            driver.FindElement(By.CssSelector("input[name='home']")).Clear();
            driver.FindElement(By.CssSelector("input[name='home']")).SendKeys(adressEntry.TelephoneHome);
            driver.FindElement(By.CssSelector("input[name='mobile']")).Clear();
            driver.FindElement(By.CssSelector("input[name='mobile']")).SendKeys(adressEntry.TelephoneMobile);
            driver.FindElement(By.CssSelector("input[name='work']")).Clear();
            driver.FindElement(By.CssSelector("input[name='work']")).SendKeys(adressEntry.TelephoneWork);
            driver.FindElement(By.CssSelector("input[name='fax']")).Clear();
            driver.FindElement(By.CssSelector("input[name='fax']")).SendKeys(adressEntry.TelephoneFax);
            driver.FindElement(By.CssSelector("input[name='email']")).Clear();
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys(adressEntry.Email);
            driver.FindElement(By.CssSelector("input[name='email2']")).Clear();
            driver.FindElement(By.CssSelector("input[name='email2']")).SendKeys(adressEntry.Email2);
            driver.FindElement(By.CssSelector("input[name='email3']")).Clear();
            driver.FindElement(By.CssSelector("input[name='email3']")).SendKeys(adressEntry.Email3);
            driver.FindElement(By.CssSelector("input[name='homepage']")).Clear();
            driver.FindElement(By.CssSelector("input[name='homepage']")).SendKeys(adressEntry.Homepage);

            var bday = driver.FindElement(By.CssSelector("select[name='bday']"));
            var selectElement = new SelectElement(bday);
            selectElement.SelectByValue(adressEntry.BirthdayDay.ToString());

            var bmonth = driver.FindElement(By.CssSelector("select[name='bmonth']"));
            selectElement = new SelectElement(bmonth);
            selectElement.SelectByValue(adressEntry.BirthdayMonth);

            driver.FindElement(By.CssSelector("input[name='byear']")).Clear();
            driver.FindElement(By.CssSelector("input[name='byear']")).SendKeys(adressEntry.BirthdayYear.ToString());

            var aday = driver.FindElement(By.CssSelector("select[name='aday']"));
            selectElement = new SelectElement(aday);
            selectElement.SelectByValue(adressEntry.BirthdayDay.ToString());

            var amonth = driver.FindElement(By.CssSelector("select[name='amonth']"));
            selectElement = new SelectElement(amonth);
            selectElement.SelectByValue(adressEntry.BirthdayMonth);

            driver.FindElement(By.CssSelector("input[name='ayear']")).Clear();
            driver.FindElement(By.CssSelector("input[name='ayear']")).SendKeys(adressEntry.AnniversaryYear.ToString());
            driver.FindElement(By.CssSelector("textarea[name='address2']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address2']")).SendKeys(adressEntry.SecondaryAddress);
            driver.FindElement(By.CssSelector("input[name='phone2']")).Clear();
            driver.FindElement(By.CssSelector("input[name='phone2']")).SendKeys(adressEntry.SecondaryTelephone);
            driver.FindElement(By.CssSelector("textarea[name='notes']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='notes']")).SendKeys(adressEntry.SecondaryNotes);
        }

        protected void InitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
        }
    }
}

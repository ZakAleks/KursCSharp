using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    internal class ContactHelper : BaseHelper
    {

        public ContactHelper(ApplicationManager Manager) :base(Manager)
        {
        }

        public ContactHelper Create(AddressBookEntryData adressEntry)
        {
            manager.Navigator.GoToAddContactPage();
            FillAdressEntryForm(adressEntry);
            InitContactCreation();
            return this;
        }

        public ContactHelper FillAdressEntryForm(AddressBookEntryData adressEntry)
        {
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
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
            return this;
        }
    }
}

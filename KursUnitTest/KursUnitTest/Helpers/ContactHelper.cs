using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    public class ContactHelper : BaseHelper
    {

        public ContactHelper(ApplicationManager Manager) :base(Manager)
        {
        }

        public ContactHelper Create(AddressBookEntryData contactData)
        {
            manager.Navigator.GoToAddContactPage();
            FillAdressEntryForm(contactData);
            InitContactCreation();
            return this;
        }

        public ContactHelper Modify(int v, AddressBookEntryData newContactData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            FillAdressEntryForm(newContactData);
            InitContactModify();
            return this;
        }

        public ContactHelper DeletFirstMetod(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            InitContactDelete();
            return this;
        }

        public ContactHelper DeletSecondMetod(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContactInMainPage(v);
            InitContactDelete();
            return this;
        }

        internal ContactHelper SelectContactInMainPage(int v)
        {
            driver.FindElement(By.XPath("(//table[@id='maintable']//tr//input[@name='selected[]'])[" + v + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("(//table[@id='maintable']//tr//img[@title='Edit'])["+ v + "]")).Click();
            return this;
        }

        public ContactHelper FillAdressEntryForm(AddressBookEntryData contactData)
        {
            Type(By.CssSelector("input[name='firstname']"), contactData.FirstName);
            Type(By.CssSelector("input[name='middlename']"), contactData.MiddleName);
            Type(By.CssSelector("input[name='lastname']"), contactData.LastName);
            Type(By.CssSelector("input[name='nickname']"), contactData.Nickname);
            Type(By.CssSelector("input[name='title']"), contactData.Title);
            Type(By.CssSelector("input[name='company']"), contactData.Company);
            Type(By.CssSelector("textarea[name='address']"), contactData.Address);
            Type(By.CssSelector("input[name='home']"), contactData.TelephoneHome);
            Type(By.CssSelector("input[name='mobile']"), contactData.TelephoneMobile);
            Type(By.CssSelector("input[name='work']"), contactData.TelephoneWork);
            Type(By.CssSelector("input[name='fax']"), contactData.TelephoneFax);
            Type(By.CssSelector("input[name='email']"), contactData.Email);
            Type(By.CssSelector("input[name='email2']"), contactData.Email2);
            Type(By.CssSelector("input[name='email3']"), contactData.Email3);
            Type(By.CssSelector("input[name='homepage']"), contactData.Homepage);

            var bday = driver.FindElement(By.CssSelector("select[name='bday']"));
            var selectElement = new SelectElement(bday);
            selectElement.SelectByValue(contactData.BirthdayDay.ToString());

            var bmonth = driver.FindElement(By.CssSelector("select[name='bmonth']"));
            selectElement = new SelectElement(bmonth);
            selectElement.SelectByValue(contactData.BirthdayMonth);

            Type(By.CssSelector("input[name='byear']"), contactData.BirthdayYear.ToString());

            var aday = driver.FindElement(By.CssSelector("select[name='aday']"));
            selectElement = new SelectElement(aday);
            selectElement.SelectByValue(contactData.AnniversaryDay.ToString());

            var amonth = driver.FindElement(By.CssSelector("select[name='amonth']"));
            selectElement = new SelectElement(amonth);
            selectElement.SelectByValue(contactData.AnniversaryMonth);

            Type(By.CssSelector("input[name='ayear']"), contactData.AnniversaryYear.ToString());
            Type(By.CssSelector("textarea[name='address2']"), contactData.SecondaryAddress);
            Type(By.CssSelector("input[name='phone2']"), contactData.SecondaryTelephone);
            Type(By.CssSelector("textarea[name='notes']"), contactData.SecondaryNotes);

            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
            return this;
        }

        public ContactHelper InitContactModify()
        {
            driver.FindElement(By.CssSelector("input[name='update'][value='Update']")).Click();
            return this;
        }

        internal ContactHelper InitContactDelete()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch
            { }
            return this;
        }
    }
}

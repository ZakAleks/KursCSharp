﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    public class ContactHelper : BaseHelper
    {

        public ContactHelper(ApplicationManager Manager) : base(Manager)
        {
        }

        public ContactHelper Create(AddressBookEntryData contactData)
        {
            manager.Navigator.GoToAddContactPage();
            FillAdressEntryForm(contactData);
            SubminContactCreation();
            ReturnsToHomePage();
            return this;
        }

        public void DelContactfromGroup(AddressBookEntryData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFilter(group.Id);
            SelectContactInMainPage(contact.Id);
            CommitDeletingContactfromGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div[class='msgbox']")).Count > 0);
        }

        internal ContactHelper SelectGroupFilter(string id)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByValue(id);
            return this;
        }

        internal ContactHelper CommitDeletingContactfromGroup()
        {
            driver.FindElement(By.CssSelector("input[name='remove']")).Click();
            return this;
        }

        public void AddContactToGroup(AddressBookEntryData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContactInMainPage(contact.Id);
            SelectGroupToAdd(group.GroupName);
            CommitAddingContactToGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div[class='msgbox']")).Count > 0);

        }

        internal ContactHelper SelectGroupToAdd(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(groupName);

            return this;
        }

        internal ContactHelper ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");

            return this;
        }

        internal ContactHelper CommitAddingContactToGroup()
        {
            driver.FindElement(By.CssSelector("input[name='add']")).Click();
            return this;
        }

        internal ContactHelper SelectContactInMainPage(string id)
        {
            driver.FindElement(By.CssSelector("input[id='"+ id + "']")).Click();
            return this;
        }

        public ContactHelper Modify(int v, AddressBookEntryData newContactData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            FillAdressEntryForm(newContactData);
            SubmitContactModify();
            ReturnsToHomePage();
            return this;
        }

        public int GetContactsCounts()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count();
        }

        private List<AddressBookEntryData> ContactCache = null;

        public List<AddressBookEntryData> GetContactsList()
        {
            if (ContactCache == null)
            {
                ContactCache = new List<AddressBookEntryData>();

                manager.Navigator.GoToHomePage();
                var trEls = driver.FindElements(By.CssSelector("tr[name='entry']"));

                foreach (var el in trEls)
                {

                    var tds = el.FindElements(By.CssSelector("td"));
                    AddressBookEntryData contactData = new AddressBookEntryData();

                    contactData.Id = tds[0].FindElement(By.CssSelector("input")).GetAttribute("value");
                    contactData.FirstName = tds[2].Text;
                    contactData.LastName = tds[1].Text;
                    ContactCache.Add(contactData);
                }

            }
            return new List<AddressBookEntryData>(ContactCache);
        }

        public ContactHelper DeletFirstMetod(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            SubmitContactDelete();
            ReturnsToHomePage();
            return this;
        }

        public ContactHelper DeletFirstMetod(string id)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(id);
            SubmitContactDelete();
            ReturnsToHomePage();
            return this;
        }

        public ContactHelper DeletSecondMetod(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContactInMainPage(v);
            SubmitContactDelete();
            ReturnsToHomePage();
            return this;
        }

        public ContactHelper DeletSecondMetod(string id)
        {
            manager.Navigator.GoToHomePage();
            SelectContactInMainPage(id);
            SubmitContactDelete();
            ReturnsToHomePage();
            return this;
        }

        public string GetDetailTextFormat(AddressBookEntryData acc)
        {

            string detailDataTextFormat = (acc.FirstName + CheckEmptyString(acc.MiddleName, " ") + CheckEmptyString(acc.LastName, " ") + Environment.NewLine
                 + acc.Nickname + Environment.NewLine
                 + acc.Title + Environment.NewLine
                 + acc.Company + Environment.NewLine
                 + acc.Address + Environment.NewLine
                 + CheckEmptyString(acc.TelephoneHome, "H: ") + Environment.NewLine
                 + CheckEmptyString(acc.TelephoneMobile, "M: ") + Environment.NewLine
                 + CheckEmptyString(acc.TelephoneWork, "W: ") + Environment.NewLine
                 + CheckEmptyString(acc.TelephoneFax, "F: ") + Environment.NewLine
                 + acc.AllEmails + Environment.NewLine
                 + CheckEmptyString(acc.Homepage, "Homepage:\r\n") + Environment.NewLine
                 + acc.FullBirthdayDate + Environment.NewLine
                 + acc.FullAnniversaryDate + Environment.NewLine
                 + acc.SecondaryAddress + Environment.NewLine
                 + CheckEmptyString(acc.SecondaryTelephone, "P: ") + Environment.NewLine
                 + acc.SecondaryNotes).Trim();

            return detailDataTextFormat;
        }

        public ContactHelper Modify(AddressBookEntryData oldData, AddressBookEntryData newContactData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(oldData.Id);
            FillAdressEntryForm(newContactData);
            SubmitContactModify();
            ReturnsToHomePage();
            return this;
        }

        public AddressBookEntryData GetContactDataFromEditForm(int ind)
        {

            manager.Navigator.GoToHomePage();
            SelectContact(ind);

            AddressBookEntryData acc = new AddressBookEntryData();
            acc.FirstName = driver.FindElement(By.CssSelector("input[name='firstname']")).GetAttribute("value");
            acc.MiddleName = driver.FindElement(By.CssSelector("input[name='middlename']")).GetAttribute("value");
            acc.LastName = driver.FindElement(By.CssSelector("input[name='lastname']")).GetAttribute("value");

            acc.Nickname = driver.FindElement(By.CssSelector("input[name='nickname']")).GetAttribute("value");

            acc.Company = driver.FindElement(By.CssSelector("input[name='company']")).GetAttribute("value");

            acc.Title = driver.FindElement(By.CssSelector("input[name='title']")).GetAttribute("value");

            acc.Address = driver.FindElement(By.CssSelector("textarea[name='address']")).Text;

            acc.TelephoneHome = driver.FindElement(By.CssSelector("input[name='home']")).GetAttribute("value");
            acc.TelephoneMobile = driver.FindElement(By.CssSelector("input[name='mobile']")).GetAttribute("value");
            acc.TelephoneWork = driver.FindElement(By.CssSelector("input[name='work']")).GetAttribute("value");
            acc.TelephoneFax = driver.FindElement(By.CssSelector("input[name='fax']")).GetAttribute("value");
            acc.SecondaryTelephone = driver.FindElement(By.CssSelector("input[name='phone2']")).GetAttribute("value");

            acc.Email = driver.FindElement(By.CssSelector("input[name='email']")).GetAttribute("value");
            acc.Email2 = driver.FindElement(By.CssSelector("input[name='email2']")).GetAttribute("value");
            acc.Email3 = driver.FindElement(By.CssSelector("input[name='email3']")).GetAttribute("value");

            acc.Homepage = driver.FindElement(By.CssSelector("input[name='homepage']")).GetAttribute("value");

            acc.BirthdayDay = driver.FindElement(By.CssSelector("select[name='bday'] option[selected]")).Text;
            acc.BirthdayMonth = driver.FindElement(By.CssSelector("select[name='bmonth'] option[selected]")).Text;

            acc.BirthdayYear = driver.FindElement(By.CssSelector("input[name='byear']")).GetAttribute("value");

            acc.AnniversaryDay = driver.FindElement(By.CssSelector("select[name='aday'] option[selected]")).Text;
            acc.AnniversaryMonth = driver.FindElement(By.CssSelector("select[name='amonth'] option[selected]")).Text;
            acc.AnniversaryYear = driver.FindElement(By.CssSelector("input[name='ayear']")).GetAttribute("value");

            acc.SecondaryAddress = driver.FindElement(By.CssSelector("textarea[name='address2']")).Text;
            acc.SecondaryNotes = driver.FindElement(By.CssSelector("textarea[name='notes']")).Text;

            return acc;
        }

        public AddressBookEntryData GetContactDataFromTable(int ind)
        {

            manager.Navigator.GoToHomePage();

            AddressBookEntryData acc = new AddressBookEntryData();

            IList<IWebElement> cells = driver.FindElements(By.CssSelector("tr[name='entry']"))[ind].FindElements(By.CssSelector("td"));

            acc.FirstName = cells[2].Text;
            acc.LastName = cells[1].Text;
            acc.Address = cells[3].Text;

            acc.AllPhones = cells[5].Text;

            acc.AllEmails = cells[4].Text;

            return acc;
        }

        internal ContactHelper SelectContactInMainPage(int v)
        {
            driver.FindElement(By.XPath("(//table[@id='maintable']//tr//input[@name='selected[]'])[" + v + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("(//table[@id='maintable']//tr//img[@title='Edit'])[" + v + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.CssSelector("tr[name='entry'] a[href='edit.php?id="+ id + "']")).Click();
            return this;
        }

        public ContactHelper ReturnsToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
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

        public string GetContactDataFromDetails(int v)
        {
            manager.Navigator.GoToHomePage();
            GoToDetailPage(v);
            return driver.FindElement(By.CssSelector("div[id='content']")).Text;
        }

        private void GoToDetailPage(int v)
        {
            driver.FindElement(By.XPath("(//table//tr[@name='entry'])["+ v +"]//a[contains(@href, 'view.php?id=')]")).Click();
        }

        public ContactHelper SubminContactCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
            ContactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.CssSelector("input[name='update'][value='Update']")).Click();
            ContactCache = null;
            return this;
        }

        internal ContactHelper SubmitContactDelete()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch
            { }
            ContactCache = null;
            return this;
        }


        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            var text = driver.FindElement(By.CssSelector("label")).Text;
            var m = new Regex("\\d+").Match(text);

            return Int32.Parse(m.Value);
        }
    }
}

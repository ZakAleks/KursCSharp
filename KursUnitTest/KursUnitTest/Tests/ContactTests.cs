using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    public class ContactTests : AuthBaseTest
    {

        public static IEnumerable<AddressBookEntryData> RandomContactDataProvider()
        {
            List<AddressBookEntryData> contacts = new List<AddressBookEntryData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new AddressBookEntryData()
                {
                    FirstName = GenerateRandomString(10),
                    MiddleName = GenerateRandomString(10),
                    LastName = GenerateRandomString(10),
                    Nickname = GenerateRandomString(10),
                    Title = GenerateRandomString(20),
                    Company = GenerateRandomString(20),
                    Address = GenerateRandomString(20),
                    TelephoneHome = GenerateRandomString(20),
                    TelephoneMobile = GenerateRandomString(20),
                    TelephoneWork = GenerateRandomString(20),
                    TelephoneFax = GenerateRandomString(20),
                    Email = GenerateRandomString(20),
                    Email2 = GenerateRandomString(20),
                    Email3 = GenerateRandomString(20),
                    Homepage = GenerateRandomString(20),
                    BirthdayDay = GetRandomDay(),
                    BirthdayMonth = GetRandomMonth(),
                    BirthdayYear = GetRandomYear(),
                    AnniversaryDay = GetRandomDay(),
                    AnniversaryMonth = GetRandomMonth(),
                    AnniversaryYear = GetRandomYear(),
                    SecondaryAddress = GenerateRandomString(20),
                    SecondaryTelephone = GenerateRandomString(20),
                    SecondaryNotes = GenerateRandomString(20),
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(AddressBookEntryData contactData)
        {

            List<AddressBookEntryData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(contactData);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCounts());

            List<AddressBookEntryData> newContacts = app.Contacts.GetContactsList();

            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactModifyTest()
        {

            AddressBookEntryData newContactData = new AddressBookEntryData();
            newContactData.FirstName = "petr";
            newContactData.MiddleName = "petrov";
            newContactData.LastName = "petrovich";
            newContactData.Nickname = "petr";
            newContactData.Title = "Сват";
            newContactData.Company = "Рабочий";
            newContactData.Address = "Таганрог, какаято улица";
            newContactData.TelephoneHome = "+77777777777";
            newContactData.TelephoneMobile = "+9999999999";
            newContactData.TelephoneWork = "+3333333333";
            newContactData.TelephoneFax = "88-88-88";
            newContactData.Email = "petr@petr.ru";
            newContactData.Email2 = "-";
            newContactData.Email3 = "-";
            newContactData.Homepage = "petr.ru";
            newContactData.BirthdayDay = "20";
            newContactData.BirthdayMonth = "October";
            newContactData.BirthdayYear = "1966";
            newContactData.AnniversaryDay = "20";
            newContactData.AnniversaryMonth = "october";
            newContactData.AnniversaryYear = "2025";
            newContactData.SecondaryAddress = "-";
            newContactData.SecondaryTelephone = "-";
            newContactData.SecondaryNotes = "-";

            List<AddressBookEntryData> oldContacts = app.Contacts.GetContactsList();

            if (oldContacts.Count == 0)
            {
                var contactData = AddressBookEntryData.GetTestContact();

                app.Contacts.Create(contactData);

                oldContacts = app.Contacts.GetContactsList();
            }

            var oldData = oldContacts[0];

            app.Contacts.Modify(1, newContactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCounts());

            List<AddressBookEntryData> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts[0].LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newContactData.FirstName, contact.FirstName);
                    Assert.AreEqual(newContactData.LastName, contact.LastName);
                }
            }
        }

        [Test]
        public void ContactDeletFirstMetodTest()
        {
            app.Navigator.GoToHomePage();

            List<AddressBookEntryData> oldContacts = app.Contacts.GetContactsList();

            if (oldContacts.Count == 0)
            {
                var contactData = AddressBookEntryData.GetTestContact();

                app.Contacts.Create(contactData);

                oldContacts = app.Contacts.GetContactsList();
            }

            app.Contacts.DeletFirstMetod(1);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCounts());

            List<AddressBookEntryData> newContacts = app.Contacts.GetContactsList();

            var toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);


            foreach (var contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

        [Test]
        public void ContactDeletSecondMetodTest()
        {
            app.Navigator.GoToHomePage();

            List<AddressBookEntryData> oldContacts = app.Contacts.GetContactsList();

            if (oldContacts.Count == 0)
            {
                var contactData = AddressBookEntryData.GetTestContact();

                app.Contacts.Create(contactData);

                oldContacts = app.Contacts.GetContactsList();
            }

            app.Contacts.DeletSecondMetod(1);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCounts());

            List<AddressBookEntryData> newContacts = app.Contacts.GetContactsList();

            var toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void ContactInformationTest()
        {

            AddressBookEntryData dataFromTable = app.Contacts.GetContactDataFromTable(0);

            AddressBookEntryData dataFromEditForm = app.Contacts.GetContactDataFromEditForm(1);

            Assert.AreEqual(dataFromTable, dataFromEditForm);

            Assert.AreEqual(dataFromTable.Address, dataFromEditForm.Address);

            Assert.AreEqual(dataFromTable.AllPhones, dataFromEditForm.AllPhones);

            Assert.AreEqual(dataFromTable.AllEmails, dataFromEditForm.AllEmails);

        }

        [Test]
        public void ContactDetailInformationTest()
        {

            AddressBookEntryData dataFromEditForm = app.Contacts.GetContactDataFromEditForm(1);

            string textFormatFromEditForm = app.Contacts.RemoveDouble(app.Contacts.GetDetailTextFormat(dataFromEditForm), "\r\n");

            string textFormatFromDetails = (app.Contacts.RemoveDouble(app.Contacts.GetContactDataFromDetails(1), "\r\n")).Trim();

            Assert.AreEqual(textFormatFromDetails, textFormatFromEditForm);
        }
    }
}

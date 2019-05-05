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

        [Test]
        public void ContactCreationTest()
        {

            AddressBookEntryData contactData = new AddressBookEntryData();
            contactData.FirstName = "Ivan";
            contactData.MiddleName = "Ivanov";
            contactData.LastName = "Ivanovich";
            contactData.Nickname = "IVAV";
            contactData.Title = "Брат";
            contactData.Company = "Безработный";
            contactData.Address = "Москва, какаято улица";
            contactData.TelephoneHome = "+79111111111";
            contactData.TelephoneMobile = "+79777777777";
            contactData.TelephoneWork = "+79222222222";
            contactData.TelephoneFax = "22-22-22";
            contactData.Email = "test@ivan.ru";
            contactData.Email2 = "-";
            contactData.Email3 = "-";
            contactData.Homepage = "ivan.ru";
            contactData.BirthdayDay = "14";
            contactData.BirthdayMonth = "April";
            contactData.BirthdayYear = "1999";
            contactData.AnniversaryDay = "14";
            contactData.AnniversaryMonth = "April";
            contactData.AnniversaryYear = "2040";
            contactData.SecondaryAddress = "Питер, какаято улица";
            contactData.SecondaryTelephone = "+79333333333";
            contactData.SecondaryNotes = "Тут какаято информация о нем";

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

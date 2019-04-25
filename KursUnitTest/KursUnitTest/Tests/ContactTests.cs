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
    public class ContactTests : BaseTest
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
            contactData.BirthdayDay = 14;
            contactData.BirthdayMonth = "April";
            contactData.BirthdayYear = 1999;
            contactData.AnniversaryDay = 14;
            contactData.AnniversaryMonth = "April";
            contactData.AnniversaryYear = 2040;
            contactData.SecondaryAddress = "Питер, какаято улица";
            contactData.SecondaryTelephone = "+79333333333";
            contactData.SecondaryNotes = "Тут какаято информация о нем";

            app.Contacts.Create(contactData);
            app.Auth.LogOut();
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
            newContactData.BirthdayDay = 20;
            newContactData.BirthdayMonth = "October";
            newContactData.BirthdayYear = 1966;
            newContactData.AnniversaryDay = 20;
            newContactData.AnniversaryMonth = "october";
            newContactData.AnniversaryYear = 2025;
            newContactData.SecondaryAddress = "-";
            newContactData.SecondaryTelephone = "-";
            newContactData.SecondaryNotes = "-";

            app.Contacts.Modify(1, newContactData);
            app.Auth.LogOut();
        }

        [Test]
        public void ContactDeletFirstMetodTest()
        {
            app.Navigator.GoToHomePage();
            app.Contacts.DeletFirstMetod(1);
            app.Auth.LogOut();
        }

        [Test]
        public void ContactDeletSecondMetodTest()
        {
            app.Navigator.GoToHomePage();
            app.Contacts.DeletSecondMetod(1);
            app.Auth.LogOut();
        }
    }
}

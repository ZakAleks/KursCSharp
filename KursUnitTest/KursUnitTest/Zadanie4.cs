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
    internal class Zadanie4 : BaseTest
    {

        [Test]
        public void ContactCreationTest()
        {

            AddressBookEntryData adressEntry = new AddressBookEntryData();
            adressEntry.FirstName = "Ivan";
            adressEntry.MiddleName = "Ivanov";
            adressEntry.LastName = "Ivanovich";
            adressEntry.Nickname = "IVAV";
            adressEntry.Title = "Брат";
            adressEntry.Company = "Безработный";
            adressEntry.Address = "Москва, какаято улица";
            adressEntry.TelephoneHome = "+79111111111";
            adressEntry.TelephoneMobile = "+79777777777";
            adressEntry.TelephoneWork = "+79222222222";
            adressEntry.TelephoneFax = "22-22-22";
            adressEntry.Email = "test@ivan.ru";
            adressEntry.Email2 = "-";
            adressEntry.Email3 = "-";
            adressEntry.Homepage = "ivan.ru";
            adressEntry.BirthdayDay = 14;
            adressEntry.BirthdayMonth = "April";
            adressEntry.BirthdayYear = 1999;
            adressEntry.AnniversaryDay = 14;
            adressEntry.AnniversaryMonth = "April";
            adressEntry.AnniversaryYear = 2040;
            adressEntry.SecondaryAddress = "Питер, какаято улица";
            adressEntry.SecondaryTelephone = "+79333333333";
            adressEntry.SecondaryNotes = "Тут какаято информация о нем";


            OpenHomePage(Url);
            Login(new AccauntData("admin", "secret"));

            FillAdressEntryForm(adressEntry);

            InitContactCreation();

            LogOut();
        }
    }
}

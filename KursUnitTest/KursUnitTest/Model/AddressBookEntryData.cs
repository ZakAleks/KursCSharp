using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KursUnitTest
{

    [Table(Name = "addressbook")]
    public class AddressBookEntryData : IEquatable<AddressBookEntryData>, IComparable<AddressBookEntryData>
    {
        private string allPhones;
        private string allEmails;
        private string fullBirthdayDate;
        private string fullAnniversaryDate;

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "deprecated"), PrimaryKey]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(TelephoneHome) + CleanUp(TelephoneMobile) + CleanUp(TelephoneWork) + CleanUp(SecondaryTelephone)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }

            }
            set
            {
                allEmails = value;
            }
        }

        public string FullBirthdayDate
        {
            get
            {
                if (fullBirthdayDate != null)
                {
                    return fullBirthdayDate;
                }
                else
                {
                    if (GetFormatDate(BirthdayDay, BirthdayMonth, BirthdayYear) == "")
                        return "";
                    return ("Birthday " + GetFormatDate(BirthdayDay, BirthdayMonth, BirthdayYear)).Trim();
                }

            }
            set
            {
                fullBirthdayDate = value;
            }
        }

        public string FullAnniversaryDate
        {
            get
            {
                if (fullAnniversaryDate != null)
                {
                    return fullAnniversaryDate;
                }
                else
                {
                    if (GetFormatDate(AnniversaryDay, AnniversaryMonth, AnniversaryYear) == "")
                        return "";
                    return ("Anniversary " + GetFormatDate(AnniversaryDay, AnniversaryMonth, AnniversaryYear)).Trim();
                }

            }
            set
            {
                fullAnniversaryDate = value;
            }
        }

        private static string GetFormatDate(string day, string month, string year)
        {
            if (day == "-")
            {
                day = "";
            }
            else
            {
                day += ". ";
            }

            if (month == "-")
            {
                month = "";
            }
            else
            {
                month += " ";
            }
            int iYear;
            if (int.TryParse(year, out iYear))
            {
                if (iYear < DateTime.Now.Year + 150 && iYear > DateTime.Now.Year - 150)
                {
                    year += " (" + (DateTime.Now.Year - iYear) + ")";
                }
            }

            return day + month + year;
        }

        private string CleanUp(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }

            return Regex.Replace(text, "[ -()]", "") + "\r\n";
        }

        private string CleanUpEmail(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return text + Environment.NewLine;
        }


        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "middlename")]
        public string MiddleName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string TelephoneHome { get; set; }
        [Column(Name = "mobile")]
        public string TelephoneMobile { get; set; }
        [Column(Name = "work")]
        public string TelephoneWork { get; set; }
        [Column(Name = "fax")]
        public string TelephoneFax { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "bday")]
        public string BirthdayDay { get; set; }
        [Column(Name = "bmonth")]
        public string BirthdayMonth { get; set; }
        [Column(Name = "byear")]
        public string BirthdayYear { get; set; }
        [Column(Name = "aday")]
        public string AnniversaryDay { get; set; }
        [Column(Name = "amonth")]
        public string AnniversaryMonth { get; set; }
        [Column(Name = "ayear")]
        public string AnniversaryYear { get; set; }
        [Column(Name = "address2")]
        public string SecondaryAddress { get; set; }
        [Column(Name = "phone2")]
        public string SecondaryTelephone { get; set; }
        [Column(Name = "notes")]
        public string SecondaryNotes { get; set; }

        public AddressBookEntryData()
        {
        }

        public bool Equals(AddressBookEntryData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return FirstName == other.FirstName && LastName == other.LastName && Id == other.Id;

        }

        public override int GetHashCode()
        {
            return (FirstName + LastName +Id).GetHashCode();
        }

        public override string ToString()
        {
            return "Name=" + FirstName +"Id="+ Id;
        }

        public int CompareTo(AddressBookEntryData other)
        {
            if (Object.ReferenceEquals(other, null))
                return 1;

            var res = FirstName.CompareTo(other.FirstName);
            if (res != 0)
                return res;

            var res2 = LastName.CompareTo(other.LastName);
            if (res != 0)
                return res2;

            return Id.CompareTo(other.Id);
        }

        public static AddressBookEntryData GetTestContact()
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

            return contactData;
        }

        public static List<AddressBookEntryData> GetAll()
        {
            using (AdressBookDB db = new AdressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}

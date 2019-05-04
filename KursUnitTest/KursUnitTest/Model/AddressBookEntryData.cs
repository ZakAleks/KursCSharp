using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KursUnitTest
{
    public class AddressBookEntryData : IEquatable<AddressBookEntryData>, IComparable<AddressBookEntryData>
    {
        private string allPhones;
        private string allEmails;
        private string fullBirthdayDate;
        private string fullAnniversaryDate;

        public string Id { get; set; }

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

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string TelephoneHome { get; set; }
        public string TelephoneMobile { get; set; }
        public string TelephoneWork { get; set; }
        public string TelephoneFax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }

        public string BirthdayDay { get; set; }
        public string BirthdayMonth { get; set; }
        public string BirthdayYear { get; set; }

        public string AnniversaryDay { get; set; }
        public string AnniversaryMonth { get; set; }
        public string AnniversaryYear { get; set; }

        public string SecondaryAddress { get; set; }
        public string SecondaryTelephone { get; set; }
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

            return FirstName == other.FirstName && LastName == other.LastName;

        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return "Name=" + FirstName;
        }

        public int CompareTo(AddressBookEntryData other)
        {
            if (Object.ReferenceEquals(other, null))
                return 1;

            var res = FirstName.CompareTo(other.FirstName);
            if (res != 0)
                return res;

            return LastName.CompareTo(other.LastName);
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

    }
}

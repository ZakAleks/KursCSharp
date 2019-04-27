using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    public class AddressBookEntryData : IEquatable<AddressBookEntryData>, IComparable<AddressBookEntryData>
    {
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

        public int BirthdayDay { get; set; }
        public string BirthdayMonth { get; set; }
        public int BirthdayYear { get; set; }

        public int AnniversaryDay { get; set; }
        public string AnniversaryMonth { get; set; }
        public int AnniversaryYear { get; set; }

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
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
        }

    }
}

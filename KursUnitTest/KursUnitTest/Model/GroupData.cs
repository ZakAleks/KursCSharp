using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [Table(Name = "group_list")]

    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        [Column(Name = "group_name")]
        public string GroupName { get; set; }
        [Column(Name = "group_header")]
        public string GroupHeader { get; set; }
        [Column(Name = "group_footer")]
        public string GroupFooter { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public GroupData()
        {
        }

        public GroupData(string groupName, string groupHeader, string groupFooter)
        {
            GroupName = groupName;
            GroupHeader = groupName;
            GroupFooter = groupFooter;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return GroupName == other.GroupName && GroupHeader == other.GroupHeader && GroupFooter == other.GroupFooter && Id == other.Id;

        }

        public override int GetHashCode()
        {
            return (GroupName + GroupHeader + GroupFooter + Id).GetHashCode();
        }

        public override string ToString()
        {
            return "Name=" + GroupName + "\nHeader="+ GroupHeader + "\nFooter=" + GroupFooter;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            var res = GroupName.CompareTo(other.GroupName);
            if (res != 0)
                return res;

            return Id.CompareTo(other.Id);
        }

        public static List<GroupData> GetAll()
        {
            using (AdressBookDB db = new AdressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public List<AddressBookEntryData> GetContacts()
        {
            using (AdressBookDB db = new AdressBookDB())
            {
                return (from c in db.Contacts from gcr in db.GCR.Where(p => p.GroupID == Id && p.ContactID == c.Id && c.Deprecated == "0000-00-00 00:00:00") select c).Distinct().ToList();
            }
        }

    }
}

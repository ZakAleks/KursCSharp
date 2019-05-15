using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    public class DeletingContactFromGroupTests : AuthBaseTest
    {

        [Test]
        public void TestDeletingContactfromGroup()
        {
            List<GroupData> oldGroups = GroupData.GetAll();

            if (oldGroups.Count == 0)
            {
                GroupData newGroup = new GroupData();
                newGroup.GroupName = "test";
                newGroup.GroupHeader = "test";
                newGroup.GroupFooter = "test";
                app.Groups.Create(newGroup);

                oldGroups = GroupData.GetAll();
            }
            var group = oldGroups[0];

            List<AddressBookEntryData> oldList = group.GetContacts();

            if (oldList.Count() == 0)
            {
                var contactsNotThisGroup = AddressBookEntryData.GetAll().Except(oldList).Count();
                if (contactsNotThisGroup == 0)
                {
                    var contactData = AddressBookEntryData.GetTestContact();

                    app.Contacts.Create(contactData);
                }
                var contact = AddressBookEntryData.GetAll().Except(oldList).First();

                app.Contacts.AddContactToGroup(contact, group);
                oldList.Add(contact);
            }

            var toBeRemoved = oldList[0];

            app.Contacts.DelContactfromGroup(toBeRemoved, group);

            List<AddressBookEntryData> newList = group.GetContacts();

            oldList.RemoveAt(0);

            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}

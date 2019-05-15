using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    public class AddingContactToGroupTests : AuthBaseTest
    {

        [Test]
        public void TestAddingContactToGroup()
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

            var contactsNotThisGroup = AddressBookEntryData.GetAll().Except(oldList).Count();
            if (contactsNotThisGroup == 0)
            {
                var contactData = AddressBookEntryData.GetTestContact();

                app.Contacts.Create(contactData);

            }

            var contact = AddressBookEntryData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);


            List<AddressBookEntryData> newList = group.GetContacts();
            oldList.Add(contact);

            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}

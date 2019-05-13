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

            var group = GroupData.GetAll()[0];

            List<AddressBookEntryData> oldList = group.GetContacts();

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

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

            var group = GroupData.GetAll()[0];

            List<AddressBookEntryData> oldList = group.GetContacts();

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

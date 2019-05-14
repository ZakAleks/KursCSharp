using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    public class BaseContactTest : AuthBaseTest
    {

        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<AddressBookEntryData> fromUI = app.Contacts.GetContactsList();

                List<AddressBookEntryData> fromDB = AddressBookEntryData.GetAll();

                fromUI.Sort();
                fromDB.Sort();

                Assert.AreEqual(fromDB, fromUI);
            }

        }

    }
}

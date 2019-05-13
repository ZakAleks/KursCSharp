using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    public class BaseGroupTest : AuthBaseTest
    {

        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = app.Groups.GetGroupsList();

                List<GroupData> fromDB = GroupData.GetAll();

                fromUI.Sort();
                fromDB.Sort();

                Assert.AreEqual(fromDB, fromUI);
            }

        }

    }
}

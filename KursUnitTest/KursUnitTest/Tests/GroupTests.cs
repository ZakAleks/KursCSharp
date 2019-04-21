using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [TestFixture]
    internal class GroupTests : BaseTest
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData();
            group.GroupName = "Group Name";
            group.GroupHeader = "Group Header";
            group.GroupFooter = "Group Footer";

            app.Groups.Create(group);
            app.Auth.LogOut();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData();
            group.GroupName = "";
            group.GroupHeader = "";
            group.GroupFooter = "";

            app.Groups.Create(group);
            app.Auth.LogOut();
        }

        [Test]
        public void GroupModifyTest()
        {

            GroupData newGroupData = new GroupData();
            newGroupData.GroupName = "111111";
            newGroupData.GroupHeader = "2222";
            newGroupData.GroupFooter = "3333";

            app.Groups.Modify(1, newGroupData);
            app.Auth.LogOut();
        }

        [Test]
        public void GroupDeleteTest()
        {
            app.Groups.Delete(1);
            app.Auth.LogOut();
        }

    }
}

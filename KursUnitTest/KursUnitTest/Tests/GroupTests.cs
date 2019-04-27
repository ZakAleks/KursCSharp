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
    public class GroupTests : AuthBaseTest
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData();
            group.GroupName = "Group Name";
            group.GroupHeader = "Group Header";
            group.GroupFooter = "Group Footer";

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData();
            group.GroupName = "a'a";
            group.GroupHeader = "zzzz";
            group.GroupFooter = "zzzz";

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData();
            group.GroupName = "";
            group.GroupHeader = "";
            group.GroupFooter = "";

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void GroupModifyTest()
        {

            GroupData newGroupData = new GroupData();
            newGroupData.GroupName = "111111";
            newGroupData.GroupHeader = "2222";
            newGroupData.GroupFooter = "3333";

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Modify(1, newGroupData);

            List<GroupData> newGroups = app.Groups.GetGroupsList();

            oldGroups[0].GroupName = newGroupData.GroupName;
            oldGroups[0].GroupHeader = newGroupData.GroupHeader;
            oldGroups[0].GroupFooter = newGroupData.GroupFooter;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void GroupDeleteTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Delete(1);

            List<GroupData> newGroups = app.Groups.GetGroupsList();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

        }

    }
}

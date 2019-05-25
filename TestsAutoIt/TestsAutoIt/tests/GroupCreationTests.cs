using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestsAutoIt
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            GroupData NewGroup = new GroupData()
            {
                Name = "new group"
            };

            app.GroupHelper.AddGroup(NewGroup);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();

            oldGroups.Add(NewGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}

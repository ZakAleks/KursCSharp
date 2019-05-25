using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestsAutoIt
{
    [TestFixture]
    public class GroupDeleteTests : TestBase
    {
        [Test]
        public void TestGroupDelete()
        {
            int indRemoveElement = 0;
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            if (oldGroups.Count == 0)
            {
                GroupData NewGroup = new GroupData()
                {
                    Name = "new group"
                };
                app.GroupHelper.AddGroup(NewGroup);

                oldGroups = app.GroupHelper.GetGroupList();
            }

            var toBeRemoved = oldGroups[indRemoveElement];

            app.GroupHelper.Delete(indRemoveElement);

            Assert.AreEqual(oldGroups.Count - 1, app.GroupHelper.GetGroupsCounts());

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.RemoveAt(indRemoveElement);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

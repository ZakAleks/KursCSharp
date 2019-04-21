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
    internal class Zadanie1 : BaseTest
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
    }
}

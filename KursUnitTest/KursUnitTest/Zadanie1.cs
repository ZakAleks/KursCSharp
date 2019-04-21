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
            OpenHomePage(Url);
            Login(new AccauntData("admin","secret"));
            GoToGroupsPage();
            initGroupCreation();
            FillGroupForm(new GroupData("Group Name","Group Header","Group Footer"));
            SubmitGroupCreation();
            ReturnsToGroupPage();
            LogOut();
        }
    }
}

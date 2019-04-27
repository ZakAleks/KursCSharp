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
    public class LoginTests : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AccauntData acc = new AccauntData("admin", "secret");

            app.Auth.LogOut();

            app.Auth.Login(acc);
            Assert.IsTrue(app.Auth.IsLoggedIn(acc));
        }


        [Test]
        public void LoginWithInvalidCredentials()
        {
            AccauntData acc = new AccauntData("admin", "secret2");

            app.Auth.LogOut();

            app.Auth.Login(acc);

            Assert.IsFalse(app.Auth.IsLoggedIn(acc));
        }

    }
}

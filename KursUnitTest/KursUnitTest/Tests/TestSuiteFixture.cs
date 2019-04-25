using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        public static ApplicationManager app;

        [OneTimeSetUp]
        public void InitApplicationManager()
        {
            app = new ApplicationManager();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccauntData("admin", "secret"));
        }

        [OneTimeTearDown]
        public void StopApplicationManager()
        {
            app.DeInit();
        }

    }
}

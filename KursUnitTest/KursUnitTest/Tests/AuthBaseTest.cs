using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    public class AuthBaseTest : BaseTest
    {
        [SetUp]
        public void SetUpLogin()
        {
            app.Auth.Login(new AccauntData("admin", "secret"));

        }

    }

}

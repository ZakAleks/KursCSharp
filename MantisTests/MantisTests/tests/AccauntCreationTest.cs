using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace MantisTests
{

    [TestFixture]
    public class AccauntCreationTest : BaseTest
    {

        [OneTimeSetUp]
        public void SetUpConfig()
        {
            app.FtpHelper.BackUpFile("/config_inc.php");

            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.FtpHelper.Upload("/config_inc.php", localFile);
            }

        }

        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.FtpHelper.RestoreBackUpFile("/config_inc.php");
        }

        [Test]
        public void TestAccauntRegistration()
        {
            AccauntData accaunt = new AccauntData()
            {
                Username = "testuser",
                Password = "testpassvord",
                Email = "testuser@localhost.localdomain"
            };

            if (app.James.Verify(accaunt))
            {
                app.James.Del(accaunt);
            }
            app.James.Add(accaunt);

            app.Registration.Register(accaunt);

            app.James.Del(accaunt);
        }
    }
}

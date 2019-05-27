using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace MantisTests
{

    [TestFixture]
    public class ProectCreationTest : BaseTest
    {

        [Test]
        public void TestProectCreation()
        {

            var admin = AccauntData.GetAdminAccaunt();

            var newProect = new ProectData();
            newProect.ProectName = "Proect_" + DateTime.Now.ToString("yyyyMMddHHmmss");

            app.Login.Login(admin);

            List<string> oldProjects = app.Proect.GetProjectList();

            app.Proect.CreateProject(newProect);

            List<string> newProjects = app.Proect.GetProjectList();


            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(newProect.ProectName);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}

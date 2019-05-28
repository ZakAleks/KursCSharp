using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace MantisTests
{

    [TestFixture]
    public class ProectDeleteTest : BaseTest
    {
        [Test]
        public void TestProectDelete()
        {
            var admin = AccauntData.GetAdminAccaunt();

            app.Login.Login(admin);

            List<ProectData> oldProjects = app.API.GetProjectList(admin);

            if (oldProjects.Count == 0)
            {
                var newProect = new ProectData();
                newProect.ProectName = "Proect_" + DateTime.Now.ToString("yyyyMMddHHmmss");

                app.API.CreateProject(admin, newProect);

                oldProjects = app.API.GetProjectList(admin);
            }

            var toBeRemoved = oldProjects[0];

            app.Proect.Delete(toBeRemoved.ProectName);

            List<ProectData> newProjects = app.API.GetProjectList(admin);

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(0);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

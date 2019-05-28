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

            List<string> oldProjects = app.Proect.GetProjectList();

            if (oldProjects.Count == 0)
            {
                var newProect = new ProectData();
                newProect.ProectName = "Proect_" + DateTime.Now.ToString("yyyyMMddHHmmss");

                app.Proect.CreateProject(newProect);

                oldProjects = app.Proect.GetProjectList();
            }

            var toBeRemoved = oldProjects[0];

            app.Proect.Delete(toBeRemoved);

            List<string> newProjects = app.Proect.GetProjectList();

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(0);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}

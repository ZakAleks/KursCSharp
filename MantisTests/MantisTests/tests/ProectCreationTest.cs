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

            ProectData newProect = new ProectData();
            newProect.ProectName = "Proect_" + DateTime.Now.ToString("yyyyMMddHHmmss");

            app.Login.Login(admin);

            List<ProectData> oldProjects = app.API.GetProjectList(admin);

            app.Proect.CreateProject(newProect);

            List<ProectData> newProjects = app.API.GetProjectList(admin);

            ProectData existProject = newProjects.Find(x => x.ProectName == newProect.ProectName);
            if (existProject!=null)
            {
                newProect.Id = existProject.Id;
            }
            else
            {
                Assert.Fail("что-то пошло не так и проект не добавился");
            }

            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(newProect);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

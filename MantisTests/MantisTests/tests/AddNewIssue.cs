using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace MantisTests
{

    [TestFixture]
    public class AddNewIssue : BaseTest
    {
        [Test]
        public void TestAddNewIssue()
        {
            AccauntData accaunt = AccauntData.GetAdminAccaunt();
            ProectData proect = new ProectData();
            proect.Id = "1";
            IssueData issueData = new IssueData();
            issueData.Category = "General";
            issueData.Summary = "short text";
            issueData.Description = "long text";
            app.API.CreateNewIssue(accaunt, issueData, proect);
        }
    }
}

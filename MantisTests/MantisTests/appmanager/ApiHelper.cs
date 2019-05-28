using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MantisTests
{
    public class APIHelper : BaseHelper
    {
        private string baseUrl;

        public APIHelper(ApplicationManager Manager) : base(Manager)
        {
        }

        public void CreateNewIssue(AccauntData accaunt, IssueData issueData, ProectData proect)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = proect.Id;
            client.mc_issue_add(accaunt.Username, accaunt.Password, issue);
        }

        internal void CreateProject(AccauntData accaunt, ProectData newProect)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData proect = new Mantis.ProjectData();
            proect.name = newProect.ProectName;
            client.mc_project_add(accaunt.Username, accaunt.Password, proect);
        }

        public List<ProectData> GetProjectList(AccauntData accaunt)
        {
            List<ProectData> proects = new List<ProectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            var proectList = client.mc_projects_get_user_accessible(accaunt.Username, accaunt.Password);
            foreach (var pr in proectList)
            {
                ProectData proect = new ProectData();
                proect.ProectName = pr.name;
                proect.Id = pr.id;
                proects.Add(proect);
            }

            return proects;
        }
    }
}

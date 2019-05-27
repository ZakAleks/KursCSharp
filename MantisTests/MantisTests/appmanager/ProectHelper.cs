using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MantisTests
{
    public class ProectHelper : BaseHelper
    {
        public ProectHelper(ApplicationManager Manager) : base(Manager)
        {
        }

        private List<string> ProjectCach = null;

        public List<string> GetProjectList()
        {
            if (ProjectCach == null)
            {
                ProjectCach = new List<string>();

                manager.Navigator.GoToProjectsPage();

                var elPs = driver.FindElements(By.CssSelector("table tbody a[href*='?project_id=']"));

                foreach (var pr in elPs)
                {
                    string name = pr.Text;

                    ProjectCach.Add(name);
                }

            }
            return new List<string>(ProjectCach);
        }

        internal void Delete(string nameRemProject)
        {
            manager.Navigator.GoToProjectsPage();
            SelectProject(nameRemProject);
            InitProjectDelete();
            manager.Navigator.GoToProjectsPage();
        }

        private void SelectProject(string nameRemProject)
        {
            driver.FindElement(By.XPath("//a[text()='"+ nameRemProject + "']")).Click();
        }

        private void InitProjectDelete()
        {
            driver.FindElement(By.CssSelector("form[id='project-delete-form'] input.btn-primary")).Click();
            driver.FindElement(By.CssSelector("input.btn-primary")).Click();
            ProjectCach = null;
        }

        public void CreateProject(ProectData newProect)
        {
            manager.Navigator.GoToProjectsPage();
            InitProjectCreation();
            FillProjectForm(newProect);
            SubmitProjectCreation();
            manager.Navigator.GoToProjectsPage();
        }

        private void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("div.clearfix>input")).Click();
            ProjectCach = null;
        }

        private void FillProjectForm(ProectData newProect)
        {
            driver.FindElement(By.CssSelector("input[id='project-name']")).SendKeys(newProect.ProectName);
        }

        private void InitProjectCreation()
        {
            driver.FindElement(By.CssSelector("div.clearfix>form button")).Click();
        }
    }
}

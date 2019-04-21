using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    internal class GroupHelper : BaseHelper
    {

        public GroupHelper(ApplicationManager Manager) : base(Manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnsToGroupPage();
            return this;
        }

        public GroupHelper ReturnsToGroupPage()
        {
            driver.FindElement(By.CssSelector("div[class='msgbox'] a[href$='group.php']")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys(group.GroupName);
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).SendKeys(group.GroupHeader);
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).SendKeys(group.GroupFooter);
            return this;

        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='new']")).Click();
            return this;
        }
    }
}

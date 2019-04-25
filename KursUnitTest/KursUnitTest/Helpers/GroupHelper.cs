using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    public class GroupHelper : BaseHelper
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

        public GroupHelper Modify(int v, GroupData newGroupData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModify();
            FillGroupForm(newGroupData);
            SubmitGroupModify();
            return this;
        }

        public GroupHelper Delete(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupDelete();
            return this;
        }

        public GroupHelper SelectGroup(int v)
        {
            driver.FindElement(By.XPath("(//form//input[@name='selected[]'])["+ v +"]")).Click();
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

        public GroupHelper SubmitGroupModify()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.CssSelector("input[name='group_name']"), group.GroupName);
            Type(By.CssSelector("textarea[name='group_header']"), group.GroupHeader);
            Type(By.CssSelector("textarea[name='group_footer']"), group.GroupFooter);

            return this;

        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='new']")).Click();
            return this;
        }

        public GroupHelper InitGroupModify()
        {
            driver.FindElement(By.CssSelector("input[name='edit']")).Click();
            return this;
        }

        public GroupHelper InitGroupDelete()
        {
            driver.FindElement(By.CssSelector("input[name='delete']")).Click();
            return this;
        }
    }
}

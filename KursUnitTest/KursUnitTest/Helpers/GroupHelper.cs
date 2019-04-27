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
            if (!IsElementPresent(By.CssSelector("span[class='group']")))
            {
                GroupData group = new GroupData();
                group.GroupName = "";
                group.GroupHeader = "";
                group.GroupFooter = "";

                Create(group);
            }
            SelectGroup(v);
            InitGroupModify();
            FillGroupForm(newGroupData);
            SubmitGroupModify();
            return this;
        }

        public List<GroupData> GetGroupsList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            var chkEls = driver.FindElements(By.CssSelector("span[class='group'] input"));
            List<string> valueGroup = new List<string>();
            foreach (var el in chkEls)
            {
                var val = el.GetAttribute("value");
                valueGroup.Add(val);
            }

            foreach (var valid in valueGroup)
            {
                GroupData groupData = new GroupData();
                driver.FindElement(By.CssSelector("span[class='group'] input[value='" + valid + "']")).Click();
                driver.FindElement(By.CssSelector("input[name='edit']")).Click();

                GetGroupData(groupData);
                manager.Navigator.GoToGroupsPage();

                groups.Add(groupData);
            }


            return groups;
        }

        public void GetGroupData(GroupData groupData)
        {
            groupData.GroupName = driver.FindElement(By.CssSelector("input[name='group_name']")).GetAttribute("value");
            groupData.GroupHeader = driver.FindElement(By.CssSelector("textarea[name='group_header']")).Text;
            groupData.GroupFooter = driver.FindElement(By.CssSelector("textarea[name='group_footer']")).Text;
        }

        public GroupHelper Delete(int v)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.CssSelector("span[class='group']")))
            {
                GroupData group = new GroupData();
                group.GroupName = "";
                group.GroupHeader = "";
                group.GroupFooter = "";

                Create(group);
            }
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

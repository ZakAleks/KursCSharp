﻿using OpenQA.Selenium;
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
            ReturnsToGroupPage();
            return this;
        }

        private List<GroupData> GroupCach = null;

        public List<GroupData> GetGroupsList()
        {
            if (GroupCach==null)
            {
                GroupCach = new List<GroupData>();

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
                    GroupData groupData = new GroupData() { Id = valid };
                    driver.FindElement(By.CssSelector("span[class='group'] input[value='" + valid + "']")).Click();
                    driver.FindElement(By.CssSelector("input[name='edit']")).Click();
                    GetGroupData(groupData);
                    manager.Navigator.GoToGroupsPage();

                    GroupCach.Add(groupData);
                }

            }

            return new List<GroupData>(GroupCach);
        }

        public int GetGroupsCounts()
        {
            
            return driver.FindElements(By.CssSelector("span[class='group'] input")).Count;
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
            SelectGroup(v);
            InitGroupDelete();
            ReturnsToGroupPage();
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
            GroupCach = null;
            return this;
        }

        public GroupHelper SubmitGroupModify()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            GroupCach = null;
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
            GroupCach = null;
            return this;
        }

        public GroupHelper Delete(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            InitGroupDelete();
            ReturnsToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData group, GroupData newGroupData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            InitGroupModify();
            FillGroupForm(newGroupData);
            SubmitGroupModify();
            ReturnsToGroupPage();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//form//input[@name='selected[]' and @value='"+ id + "'])")).Click();
            return this;
        }
    }
}

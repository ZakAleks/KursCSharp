using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace KursUnitTest
{
    [TestFixture]
    public class GroupTests : BaseGroupTest
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData()
                {
                    GroupName = GenerateRandomString(30),
                    GroupHeader = GenerateRandomString(100),
                    GroupFooter = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();

            string[] lines = File.ReadAllLines("groups.csv");

            foreach (var l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData()
                {
                    GroupName = parts[0],
                    GroupHeader = parts[1],
                    GroupFooter = parts[2]
                }
                    );
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader("groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText("groups.json"));

        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), "groups.xls"));
            Excel.Worksheet ws = wb.Sheets[1];
            Excel.Range range = ws.UsedRange;

            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    GroupName = range.Cells[i, 1].Value,
                    GroupHeader = range.Cells[i, 2].Value,
                    GroupFooter = range.Cells[i, 3].Value
                });
            }

            wb.Close();
            app.Quit();
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromExcelFile")]
        public void GroupCreationTest(GroupData group)
        {

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCounts());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData();
            group.GroupName = "a'a";
            group.GroupHeader = "zzzz";
            group.GroupFooter = "zzzz";

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCounts());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void GroupModifyTest()
        {

            GroupData newGroupData = new GroupData();
            newGroupData.GroupName = "111111";
            newGroupData.GroupHeader = "2222";
            newGroupData.GroupFooter = "3333";

            List<GroupData> oldGroups = GroupData.GetAll();

            if (oldGroups.Count == 0)
            {
                GroupData group = new GroupData();
                group.GroupName = "";
                group.GroupHeader = "";
                group.GroupFooter = "";
                app.Groups.Create(group);

                oldGroups = GroupData.GetAll();
            }

            var oldData = oldGroups[0];

            app.Groups.Modify(oldData, newGroupData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCounts());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[0].GroupName = newGroupData.GroupName;
            oldGroups[0].GroupHeader = newGroupData.GroupHeader;
            oldGroups[0].GroupFooter = newGroupData.GroupFooter;
            //oldGroups.Sort();
            //newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (var group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newGroupData.GroupName, group.GroupName);
                    Assert.AreEqual(newGroupData.GroupHeader, group.GroupHeader);
                    Assert.AreEqual(newGroupData.GroupFooter, group.GroupFooter);
                }
            }

        }

        [Test]
        public void GroupDeleteTest()
        {

            List<GroupData> oldGroups = GroupData.GetAll();

            var toBeRemoved = oldGroups[0];

            if (oldGroups.Count == 0)
            {
                GroupData group = new GroupData();
                group.GroupName = "";
                group.GroupHeader = "";
                group.GroupFooter = "";
                app.Groups.Create(group);

                oldGroups = GroupData.GetAll();
            }

            app.Groups.Delete(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCounts());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (var group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }

        [Test]
        public void TestDBConnectivity()
        {

            var start = DateTime.Now;
            List<GroupData> fromUserInterface = app.Groups.GetGroupsList();
            var end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));


            start = DateTime.Now;
            List<GroupData> fromDB = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

        }

        [Test]
        public void TestDBConnectivity2()
        {

            foreach (var contact in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contact);
            }

        }

    }
}

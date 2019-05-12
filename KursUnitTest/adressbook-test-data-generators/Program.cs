using KursUnitTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace adressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string type = args[3];
            StreamWriter writer = new StreamWriter(filename);
            if (type == "groups")
            {

                List<GroupData> groups = new List<GroupData>();

                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData()
                    {
                        GroupName = BaseTest.GenerateRandomString(10),
                        GroupHeader = BaseTest.GenerateRandomString(10),
                        GroupFooter = BaseTest.GenerateRandomString(10),
                    });
                }

                if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, filename);
                }
                else
                {
                    if (format == "csv")
                    {
                        writeGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Неизвестный формат" + format);
                    }

                    writer.Close();
                }
            }
            else if (type == "contacts")
            {

                List<AddressBookEntryData> contacts = new List<AddressBookEntryData>();

                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new AddressBookEntryData()
                    {
                        FirstName = BaseTest.GenerateRandomString(10),
                        MiddleName = BaseTest.GenerateRandomString(10),
                        LastName = BaseTest.GenerateRandomString(10),
                        Nickname = BaseTest.GenerateRandomString(10),
                        Title = BaseTest.GenerateRandomString(20),
                        Company = BaseTest.GenerateRandomString(20),
                        Address = BaseTest.GenerateRandomString(20),
                        TelephoneHome = BaseTest.GenerateRandomString(20),
                        TelephoneMobile = BaseTest.GenerateRandomString(20),
                        TelephoneWork = BaseTest.GenerateRandomString(20),
                        TelephoneFax = BaseTest.GenerateRandomString(20),
                        Email = BaseTest.GenerateRandomString(20),
                        Email2 = BaseTest.GenerateRandomString(20),
                        Email3 = BaseTest.GenerateRandomString(20),
                        Homepage = BaseTest.GenerateRandomString(20),
                        BirthdayDay = BaseTest.GetRandomDay(),
                        BirthdayMonth = BaseTest.GetRandomBirthdayMonth(),
                        BirthdayYear = BaseTest.GetRandomYear(),
                        AnniversaryDay = BaseTest.GetRandomDay(),
                        AnniversaryMonth = BaseTest.GetRandomBirthdayMonth(),
                        AnniversaryYear = BaseTest.GetRandomYear(),
                        SecondaryAddress = BaseTest.GenerateRandomString(20),
                        SecondaryTelephone = BaseTest.GenerateRandomString(20),
                        SecondaryNotes = BaseTest.GenerateRandomString(20)


                    });
                }

                if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Неизвестный формат" + format);
                }

                writer.Close();
            }
            else
            {
                System.Console.Out.Write("Неизвестный тип данных" + type);
            }

        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (var group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.GroupName,
                    group.GroupHeader,
                    group.GroupFooter
                    ));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactsToXmlFile(List<AddressBookEntryData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<AddressBookEntryData>)).Serialize(writer, contacts);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToJsonFile(List<AddressBookEntryData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet ws = wb.ActiveSheet;

            int row = 1;
            foreach (var group in groups)
            {
                ws.Cells[row, 1] = group.GroupName;
                ws.Cells[row, 2] = group.GroupHeader;
                ws.Cells[row, 3] = group.GroupFooter;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }
    }
}

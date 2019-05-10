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

            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData() {
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
                StreamWriter writer = new StreamWriter(filename);
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

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
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

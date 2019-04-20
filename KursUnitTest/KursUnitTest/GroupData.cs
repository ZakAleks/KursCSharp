using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    class GroupData
    {
        public string GroupName { get; set; }
        public string GroupHeader { get; set; }
        public string GroupFooter { get; set; }

        public GroupData()
        {
        }

        public GroupData(string groupName, string groupHeader, string groupFooter)
        {
            GroupName = groupName;
            GroupHeader = groupName;
            GroupFooter = groupFooter;
        }
    }
}

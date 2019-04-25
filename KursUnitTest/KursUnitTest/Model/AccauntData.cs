using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    public class AccauntData
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AccauntData()
        {
        }

        public AccauntData(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}

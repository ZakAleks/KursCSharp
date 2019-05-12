using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest
{
    public class AdressBookDB : LinqToDB.Data.DataConnection
    {

        public AdressBookDB() : base("AdressBook")
        {

        }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<AddressBookEntryData> Contacts { get { return GetTable<AddressBookEntryData>(); } }

    }
}

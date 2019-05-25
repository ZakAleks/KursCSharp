using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace TestsAutoIt
{
    public class ApplicationManager
    {
        private AutoItX3 aux;
        private GroupHelper groupHelper;
        public static string WINTITLE = "Free Address Book";

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"c:\install\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            WaitOpenWindow(WINTITLE);

            groupHelper = new GroupHelper(this);
        }

        public void WaitOpenWindow(string WINTITLE)
        {
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }
        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }

        }

        public GroupHelper GroupHelper
        {
            get
            {
                return groupHelper;
            }

        }
    }
}

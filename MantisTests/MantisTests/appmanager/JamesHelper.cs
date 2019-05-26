using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace MantisTests
{
    public class JamesHelper : BaseHelper
    {
        public JamesHelper(ApplicationManager Manager) : base(Manager)
        {
        }

        public void Add(AccauntData accaunt)
        {
            if (Verify(accaunt))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("adduser " + accaunt.Username + " "+accaunt.Password);
            System.Console.Out.WriteLine(telnet.Read());
        }

        public void Del(AccauntData accaunt)
        {
            if (!Verify(accaunt))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("deluser " + accaunt.Username);
            System.Console.Out.WriteLine(telnet.Read());

        }

        private TelnetConnection LoginToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            return telnet;
        }

        public bool Verify(AccauntData accaunt)
        {
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("verify " + accaunt.Username);
            string text = telnet.Read();
            System.Console.Out.WriteLine(text);

            return !text.Contains("does not exist");
        }

    }
}

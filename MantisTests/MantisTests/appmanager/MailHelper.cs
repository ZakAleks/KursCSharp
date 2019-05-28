using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpaqueMail;

namespace MantisTests
{
    public class MailHelper : BaseHelper
    {

        public MailHelper(ApplicationManager Manager) : base(Manager)
        {
        }

        public string GetLastMail(AccauntData accaunt)
        {
            for (int i = 0; i < 20; i++)
            {
                Pop3Client pop3 = new Pop3Client("localhost", 110, accaunt.Username, accaunt.Password, false);
                pop3.Connect();
                pop3.Authenticate();
                var count = pop3.GetMessageCount();

                if (count > 0)
                {
                    var message = pop3.GetMessage(1);
                    var body = message.Body;
                    pop3.DeleteMessage(1);
                    pop3.LogOut();
                    return body;
                }
                Thread.Sleep(3000);
            }

            return null;
        }
    }
}

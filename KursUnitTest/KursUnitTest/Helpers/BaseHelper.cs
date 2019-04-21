using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    internal class BaseHelper
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public BaseHelper(ApplicationManager Manager)
        {
            manager = Manager;
            driver = Manager.Driver;
        }
    }
}

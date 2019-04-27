using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursUnitTest.Helpers
{
    public class BaseHelper
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public BaseHelper(ApplicationManager Manager)
        {
            manager = Manager;
            driver = Manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            { 
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }

    }
}

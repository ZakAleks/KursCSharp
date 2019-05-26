using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests
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

        public string RemoveDouble(string text, string removeSymbol)
        {
            while (true)
            {
                int ishTextLength = text.Length;
                text = text.Replace(removeSymbol + removeSymbol, removeSymbol);
                if (text.Length == ishTextLength)
                {
                    return text;
                }
            }
        }

        public string CheckEmptyString(string text, string title)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            return title + text;
        }
    }
}

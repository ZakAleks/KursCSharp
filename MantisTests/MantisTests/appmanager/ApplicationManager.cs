﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MantisTests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        //protected WebDriverWait wait;
        protected string url;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            url = "http://localhost/mantisbt-2.21.0/";
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.AddArguments("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Registration = new RegistrationHelper(this);
            FtpHelper = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Proect = new ProectHelper(this);
            Navigator = new NavigatorHelper(this);
            Login = new LoginHelper(this);
            Admin = new AdminHelper(this, url);
            API = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            driver.Quit();
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Driver.Url = newInstance.url + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration { get; private set; }
        public FtpHelper FtpHelper { get; private set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }
        public ProectHelper Proect { get; private set; }
        public NavigatorHelper Navigator { get; private set; }
        public LoginHelper Login { get; private set; }
        public AdminHelper Admin { get; private set; }
        public APIHelper API { get; private set; }
    }
}

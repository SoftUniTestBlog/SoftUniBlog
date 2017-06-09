using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Linq;

namespace UITests.Pages
{
    public class BasePage
    {
        protected string url = ConfigurationManager.AppSettings["URL"];
        private IWebDriver driver;
        private WebDriverWait wait;


        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return wait;
            }
        }

        public void NavigateToHomePage()
        {
            Driver.Navigate().GoToUrl(this.url);
            this.Driver.Manage().Window.Maximize();
        }

        

    }
}
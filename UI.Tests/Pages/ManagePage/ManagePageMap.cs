using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.ManagePage
{
    public partial class ManagePage
    {
        //Second Commit
        public IWebElement EmailFieldLogin
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
                return Driver.FindElement(By.Id("Email"));
            }
        }

        public IWebElement PasswordFieldLogin
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Password")));
                return Driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement LoginSubmitButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("btn")));
                return Driver.FindElement(By.ClassName("btn"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("loginLink")));
                return Driver.FindElement(By.Id("loginLink"));
            }
        }

        public IWebElement Logo
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("navbar-brand")));
                return this.Driver.FindElement(By.ClassName("navbar-brand"));

            }
        }

        public IWebElement Copyright
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/footer/p")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/footer/p"));
            }
        }

        public IWebElement CreateButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.LinkText("Create")));
                return Driver.FindElement(By.LinkText("Create"));
            }
        }

        public IWebElement CreatePageLogo
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h2")));
                return Driver.FindElement(By.CssSelector("h2"));
            }
        }
    }
}

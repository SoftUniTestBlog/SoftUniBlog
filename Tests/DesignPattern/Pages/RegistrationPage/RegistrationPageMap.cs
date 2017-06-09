using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTests.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {

        //Registration page map by Tsvetomir Pavlov
        public IWebElement Email
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
                return Driver.FindElement(By.Id("Email"));
            }
        }

        public IWebElement FullName
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("FullName")));
                return Driver.FindElement(By.Id("FullName"));
            }
        }
        
        public IWebElement Password
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Password")));
                return Driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("ConfirmPassword")));
                return Driver.FindElement(By.Id("ConfirmPassword"));
            }
        }

        public IWebElement RegisterSubmitButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input"));
            }
        }

        public IWebElement SoftUniBlogButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("navbar-brand")));
                return this.Driver.FindElement(By.ClassName("navbar-brand"));

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

        public IWebElement Copyright
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/footer/p")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/footer/p"));
            }
        }

        public IWebElement RegisterButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("registerLink")));
                return Driver.FindElement(By.Id("registerLink"));
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

        public IWebElement HelloMessage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.PartialLinkText("Hello")));
                return Driver.FindElement(By.PartialLinkText("Hello"));
            }
        }

        public IWebElement EmailFieldRequired
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement IncorrectEmail
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement FullNameEmpty
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement PasswordEmpty
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]"));
            }
        }

        public IWebElement ConfirmPasswordEmpty
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement PasswordMismatch
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement HomePage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/div[1]/article/header/h2/a")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/article/header/h2/a"));
            }
        }

        public IWebElement LoginPage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/h2")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement RegistrationPageForm
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/h2")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

      
    }

}

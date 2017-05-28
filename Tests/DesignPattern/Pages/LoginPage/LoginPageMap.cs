using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.LoginPage
{
    public partial class LoginPage
    {
        public IWebElement Email
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
                return Driver.FindElement(By.Id("Email"));
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

        public IWebElement RemeberMeCheckbox
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("RememberMe")));
                return Driver.FindElement(By.Id("RememberMe"));
            }
        }

        public IWebElement LoginSubmitButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
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

        public IWebElement SoftUniBlogButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("navbar-brand")));
                return this.Driver.FindElement(By.ClassName("navbar-brand"));

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

        public IWebElement EmptyEmail
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span"));
            }
        }

        public IWebElement IncorrectEmail
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span"));
            }
        }

        public IWebElement EmptyPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/span/span")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/span/span"));
            }
        }

        public IWebElement IncorrectPassword
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
    }
}

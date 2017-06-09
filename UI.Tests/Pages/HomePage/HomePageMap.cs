using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace UITests.Pages.HomePage
{
    public partial class HomePage
    {

        //FirstCommit
        public IWebElement RegistrationButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.LinkText("Register")));
                return this.Driver.FindElement(By.LinkText("Register"));
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

        public IWebElement RegisterPageLogo
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/h2")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
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

        public IWebElement LoginPageLogo
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/h2")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
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

        public IWebElement LogOffButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.LinkText("Log off")));
                return Driver.FindElement(By.LinkText("Log off"));
            }
        }

        public IWebElement ManageButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a")));
                return Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a"));
            }
        }

        public IWebElement ManagePageLogo
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h2")));
                return Driver.FindElement(By.CssSelector("h2"));
            }
        }
    }
}
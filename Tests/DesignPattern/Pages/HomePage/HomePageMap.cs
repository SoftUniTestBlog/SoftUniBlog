using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace ProjectTests.Pages.HomePage
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

    }
}
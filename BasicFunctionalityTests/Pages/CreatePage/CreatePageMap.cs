using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFunctionality.Pages.CreatePage
{
    public partial class CreatePage
    {
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
        
        public IWebElement LogoffButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a")));
                return Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a"));
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

        public IWebElement ManageText
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/h2")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/h2"));
            }
        }

        public IWebElement TitleField
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Title")));
                return Driver.FindElement(By.Id("Title"));
            }
        }
        public IWebElement ContentField
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Content")));
                return Driver.FindElement(By.Id("Content"));
            }
        }

        public IWebElement CreateButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement Article
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/div[1]/article/footer/small")));
                return Driver.FindElement(By.PartialLinkText("TestArticle12345"));
            }
        }
       
            public IWebElement TitleErrorMessage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath(" /html/body/div[2]/div/div/form/div[1]/ul/li")));
                return Driver.FindElement(By.XPath(" /html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement ContentErrorMessage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement CharactersErrorMessage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]"));
            }
        }

        public IWebElement CancelButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a"));
            }
        }

        public string URL
        {
            get
            {
               
                return Driver.Url;
            }
        }
    }
}

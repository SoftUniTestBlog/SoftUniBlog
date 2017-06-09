using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.ArticleDeletePage
{
    public partial class ArticleDeletePage
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
        private bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public IWebElement FirstArticle
        {
            get
            {
               
                if (IsElementPresent(By.PartialLinkText("TestArticle12345")))
                {
                    return Driver.FindElement(By.PartialLinkText("TestArticle12345"));
                }
                else
                {
                    return Driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
                }
                      
            }
        }

        public IWebElement CancelButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/a")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/a"));
            }
        }

        public IWebElement DeleteButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input"));

            }
        }
        public IWebElement LogOffButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a")));
                return Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a"));
            }
        }
    }
}

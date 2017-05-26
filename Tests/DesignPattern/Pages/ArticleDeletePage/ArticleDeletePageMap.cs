using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.ArticleDeletePage
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

        public IWebElement FirstArticle
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/div[1]/article/header/h2/a")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/article/header/h2/a"));
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
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/a")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/a"));
            }
        }

    }
}

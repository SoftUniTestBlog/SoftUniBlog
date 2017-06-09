using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.UserListPage
{
    public partial class UserListPage
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

        public List<IWebElement> Elements
        {
            get
            {
                //this.Wait.Until(ExpectedConditions.ElementExists(By.Id("loginLink")));
                return Driver.FindElements(By.PartialLinkText("Delete")).ToList();
              

               
            }
        }

       

        public IWebElement UserNameField
        {
            get
            {
                //this.Wait.Until(ExpectedConditions.ElementExists(By.Id("loginLink")));
                return Driver.FindElement(By.Id("UserName"));
            }
        }

        public IWebElement DeleteButton
        {
            get
            {
                //this.Wait.Until(ExpectedConditions.ElementExists(By.Id("loginLink")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input"));
            }
        }

        public IWebElement CancelButton
        {
            get
            {
                //this.Wait.Until(ExpectedConditions.ElementExists(By.Id("loginLink")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/a"));
            }
        }

    }
}

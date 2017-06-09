using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTests.Pages.ChangePasswordPage
{
    public partial class ChangePasswordPage
    {

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

        public IWebElement OldPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("OldPassword")));
                return Driver.FindElement(By.Id("OldPassword"));
            }
        }

        public IWebElement NewPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("NewPassword")));
                return Driver.FindElement(By.Id("NewPassword"));
            }
        }

        public IWebElement ChangePasswordButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("btn")));
                return Driver.FindElement(By.ClassName("btn"));
            }
        }

        public IWebElement IncorrectPasswordMessage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement FirstError
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]"));
            }
        }

        public IWebElement SecondError
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]"));
            }
        }

        public IWebElement SuccessfullChangedPasswordMessage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("text-success")));
                return Driver.FindElement(By.ClassName("text-success"));
            }
        }


    }
}




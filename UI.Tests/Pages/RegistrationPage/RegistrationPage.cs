using UITests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UITests.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        //Registration page by Tsvetomir Pavlov
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.url + "/Account/Register");
            this.Driver.Manage().Window.Maximize();
        }

        public void Register()
        {
            FillEmail();
            FillFullName();
            FillPassword();
            FillConfirmPassword();
            RegisterSubmitButton.Click();

        }

        public void FillEmail()
        {
            Email.Clear();
            Email.SendKeys("shavo@abv.bg");
            

        }
        public void FillFullName()
        {
            FullName.Clear();
            FullName.SendKeys("Tsvetomir Pavlov");


        }

        public void FillPassword()
        {
            Password.Clear();
            Password.SendKeys("1111");


        }

        public void FillConfirmPassword()
        {
            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys("1111");
        }

        public void ClickRegisterButtonSubmit()
        {
            RegisterSubmitButton.Click();
        }

        public void FillIncorrectEmail()
        {
            Email.Clear();
            Email.SendKeys("shavo@abv");
        }

        public void FillConfirmPasswordMissmatch()
        {
            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys("12345");
        }

        public void ClickSoftUniBlogButton()
        {
            SoftUniBlogButton.Click(); 
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void ClickRegisterButton()
        {
            RegisterButton.Click();
        }
    }
}

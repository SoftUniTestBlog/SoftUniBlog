using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTests.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        //First commit

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.url);
            this.Driver.Manage().Window.Maximize();
        }


        public void ClickRegisterButton()
        {
            NavigateTo();
            RegistrationButton.Click();
        }

        public void ClickHomePageLogo()
        {
            NavigateTo();
            Logo.Click();
        }

        public void ClickLogInButton()
        {
            NavigateTo();
            LoginButton.Click();
        }

        //Second Commit
        public void LogInAndClickCreateButton()
        {
            LogIn();
            CreateButton.Click();
        }

        public void LogIn()
        {
            NavigateTo();
            ClickLogInButton();
            EmailFieldLogin.Clear();
            EmailFieldLogin.SendKeys("test@test.test");
            PasswordFieldLogin.Clear();
            PasswordFieldLogin.SendKeys("1234");
            LoginSubmitButton.Click();
        }

        public void LogInAndOut()
        {
            LogIn();
            LogOffButton.Click();
        }

        public void LogInAndClickManageButton()
        {
            LogIn();
            ManageButton.Click();
        }
    }
}
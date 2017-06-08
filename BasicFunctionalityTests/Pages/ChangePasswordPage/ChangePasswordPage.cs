using BasicFunctionality.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BasicFunctionality.Pages.ChangePasswordPage
{
    public partial class ChangePasswordPage : BasePage
    {
        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {

        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.url + "/Manage/ChangePassword");
            this.Driver.Manage().Window.Maximize();
        }


        public void Register()
        {
            Driver.Navigate().GoToUrl(this.url + "/Account/Register");
            Email.Clear();
            Email.SendKeys("test@test.test");
            FullName.Clear();
            FullName.SendKeys("Test User");
            Password.Clear();
            Password.SendKeys("1234");
            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys("1234");
            RegisterSubmitButton.Click();

        }

        public void LogIn()
        {
            NavigateToHomePage();
            LoginButton.Click();
            EmailFieldLogin.Clear();
            EmailFieldLogin.SendKeys("test@test.test");
            PasswordFieldLogin.Clear();
            PasswordFieldLogin.SendKeys("1234");
            LoginSubmitButton.Click();

        }

        public void LogInAsAdmin()
        {
            NavigateToHomePage();
            LoginButton.Click();
            EmailFieldLogin.Clear();
            EmailFieldLogin.SendKeys("admin@admin.com");
            PasswordFieldLogin.Clear();
            PasswordFieldLogin.SendKeys("123");
            LoginSubmitButton.Click();

        }

        public void EnterIncorrectCurrentPasswordChange()
        {
            NavigateTo();
            OldPassword.Clear();
            OldPassword.SendKeys("12345");
            NewPassword.Clear();
            NewPassword.SendKeys("123456");
            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys("123456");
            ChangePasswordButton.Click();

        }

        public void EnterEmptyConfirmPassword()
        {
            NavigateTo();
            OldPassword.Clear();
            OldPassword.SendKeys("1234");
            NewPassword.Clear();
            NewPassword.SendKeys("123456");
            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys("");
            ChangePasswordButton.Click();

        }

        public void EnterMissmatchingNewPassword()
        {
            NavigateTo();
            OldPassword.Clear();
            OldPassword.SendKeys("1234");
            NewPassword.Clear();
            NewPassword.SendKeys("123456");
            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys("12345");
            ChangePasswordButton.Click();

        }

        public void SuccessfullPasswordChange()
        {
            NavigateTo();
            OldPassword.Clear();
            OldPassword.SendKeys("1234");
            NewPassword.Clear();
            NewPassword.SendKeys("123456");
            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys("123456");
            ChangePasswordButton.Click();
        }

        public void ClickChangePasswordButton()
        {
            NavigateTo();
            ChangePasswordButton.Click();
        }
    }
}




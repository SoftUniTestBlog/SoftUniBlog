﻿using ProjectTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProjectTests.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {
        //Login page by Tsvetomir Pavlov
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.url + "/Account/Login");
            this.Driver.Manage().Window.Maximize();
        }

        public void Login()
        {
            FillEmail();
            FillPassword();
            LoginSubmitButton.Click();
        }

        public void FillEmail()
        {
            Email.Clear();
            Email.SendKeys("shavo@abv.bg");
        }

        public void FillIncorrectEmail()
        {
            Email.Clear();
            Email.SendKeys("shavo@abv");
        }
        public void FillPassword()
        {
            Password.Clear();
            Password.SendKeys("1111");
        }

        public void FillIncorrectPassword()
        {
            Password.Clear();
            Password.SendKeys("2222");
        }

        public void ClickLoginButtonSubmit()
        {
            LoginSubmitButton.Click();
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

        public void SelectCheckbox()
        {
            RemeberMeCheckbox.Click();
        }
    }
}

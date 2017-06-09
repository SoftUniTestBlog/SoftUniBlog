using ProjectTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProjectTests.Pages.ManagePage
{
    public partial class ManagePage : BasePage
    {
        public ManagePage(IWebDriver driver) : base(driver)
        {
        }

        //Second Commit
       

        public void ClickLogInButton()
        {
            NavigateToHomePage();
            LoginButton.Click();
        }



        public void LogIn()
        {
            NavigateToHomePage();
            ClickLogInButton();
            EmailFieldLogin.Clear();
            EmailFieldLogin.SendKeys("test@test.test");
            PasswordFieldLogin.Clear();
            PasswordFieldLogin.SendKeys("1234");
            LoginSubmitButton.Click();

        }

        public void NavigateTo()
        {
            LogIn();
            Driver.Navigate().GoToUrl(this.url + "/manage");
        }

        public void NavigateToAndClickSoftUniBlogButton()
        {
            NavigateTo();
            Logo.Click();
        }

        public void ClickCreateButton()
        {
            NavigateTo();
            CreateButton.Click();
        }

        public void ClickLogOffButton()
        {
            LogOffButton.Click();
        }
    }
}

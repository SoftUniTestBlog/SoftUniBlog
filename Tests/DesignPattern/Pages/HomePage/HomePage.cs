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
            RegistrationButton.Click();
        }

        public void ClickHomePageLogo()
        {
            Logo.Click();
        }

        public void ClickLogInButton()
        {
            LoginButton.Click();
        }

    }
}
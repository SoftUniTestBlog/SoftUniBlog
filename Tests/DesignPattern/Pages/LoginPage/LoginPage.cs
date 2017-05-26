using ProjectTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DesignPattern.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.url + "/Account/Login");
            this.Driver.Manage().Window.Maximize();
        }
    }
}

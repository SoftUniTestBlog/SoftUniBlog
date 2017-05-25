using ProjectTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DesignPattern.Pages.ArticleDetailsPage
{
    public partial class ArticleDetailsPage : BasePage
    {
        public ArticleDetailsPage(IWebDriver driver) : base(driver)
        {
        }




        public void LogIn()
        {
            NavigateToHomePage();
            LoginButton.Click();
            EmailFieldLogin.Clear();
            EmailFieldLogin.SendKeys("asd@abv.bg");
            PasswordFieldLogin.Clear();
            PasswordFieldLogin.SendKeys("1234");
            LoginSubmitButton.Click();

        }


        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.url + "/Article/Details/1");
        }

        public void ClickEditButton()
        {
            EditButton.Click();
        }
    }
}

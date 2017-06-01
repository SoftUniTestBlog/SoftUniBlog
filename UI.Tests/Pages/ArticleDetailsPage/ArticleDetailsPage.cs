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

        public void LogInSecondUser()
        {
            NavigateToHomePage();
            LoginButton.Click();
            EmailFieldLogin.Clear();
            EmailFieldLogin.SendKeys("user2@abv.bg");
            PasswordFieldLogin.Clear();
            PasswordFieldLogin.SendKeys("1234");
            LoginSubmitButton.Click();

        }

        public void RegisterSecondUser()
        {
            RegisterButton.Click();
            EmailFieldRegister.Clear();
            EmailFieldRegister.SendKeys("user2@abv.bg");
            FullNameFieldRegister.Clear();
            FullNameFieldRegister.SendKeys("user2");
            PasswordFieldRegister.Clear();
            PasswordFieldRegister.SendKeys("1234");
            ConfirmPasswordFieldRegister.Clear();
            ConfirmPasswordFieldRegister.SendKeys("1234");
            RegisterSubmitButton.Click();

        }


        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.url);
            Driver.FindElement(By.PartialLinkText("TestArticle12345")).Click();
            string URL = Driver.Url;
            string Id = URL.Split('/').Last();
            Driver.Navigate().GoToUrl(this.url + "/Article/Details/" + Id );
        }

        public void ClickEditButton()
        {
            EditButton.Click();
        }

        public void ClickBackButton()
        {
            BackButton.Click();
        }
        public void ClickCreateButton()
        {
            CreateButton.Click();
        }

        public void ClickLogOffButton()
        {
            LogOffButton.Click();
        }

        public void ClickManageButton()
        {
            ManageButton.Click();
        }


        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }

        public void NavigateToFirstArticle()
        {
            Driver.Navigate().GoToUrl(this.url);
            Driver.FindElement(By.PartialLinkText("TestArticle12345")).Click();
            string URL = Driver.Url;
            string Id = URL.Split('/').Last();
            Driver.Navigate().GoToUrl(this.url + "/Article/Details/" + Id);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void ClickSoftuniBlogButton()
        {
            Logo.Click();
        }



    }
}

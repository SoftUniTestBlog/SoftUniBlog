using ProjectTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DesignPattern.Pages.ArticleDeletePage
{
    public partial class ArticleDeletePage : BasePage
    {
        public ArticleDeletePage(IWebDriver driver) : base(driver)
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
            Driver.Navigate().GoToUrl(this.url);
            Driver.FindElement(By.PartialLinkText("TestArticle12345")).Click();
            string URL = Driver.Url;
            string Id = URL.Split('/').Last();
            Driver.Navigate().GoToUrl(this.url + "/Article/Delete/" + Id);
         }

        public void EditTitle()
        {
            
            TitleField.SendKeys("This should not be visible");
           
        }

        public void EditContent()
        {
            ContentField.SendKeys("This should not be visible");

        }

        public void CancelButtonClick()
        {
            CancelButton.Click();

        }

        public void DeleteButtonClick()
        {
            DeleteButton.Click();

        }
    }
}

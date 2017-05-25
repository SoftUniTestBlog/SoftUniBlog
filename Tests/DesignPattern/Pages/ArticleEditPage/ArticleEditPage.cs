using ProjectTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DesignPattern.Pages.ArticleEditPage
{
    public partial class ArticleEditPage : BasePage
    {
        public ArticleEditPage(IWebDriver driver) : base(driver)
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
            Driver.Navigate().GoToUrl(this.url + "/Article/Edit/1");
        }

        public void EditTitle()
        {
            
            TitleField.Clear();
            TitleField.SendKeys("Edit title");
            EditButton.Click();

        }

        public void EditContent(string content)
        {

            ContentField.Clear();
            ContentField.SendKeys(content);
            
        }

        public void EditButtonClick()
        {
                        
            EditButton.Click();
        }

        public void CancelButtonClick()
        {

            CancelButton.Click();
        }
    }
}

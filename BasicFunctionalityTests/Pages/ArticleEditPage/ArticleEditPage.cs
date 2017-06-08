using BasicFunctionality.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BasicFunctionality.Pages.ArticleEditPage
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
            EmailFieldLogin.SendKeys("test@test.test");
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
            Driver.Navigate().GoToUrl(this.url + "/Article/Edit/" + Id);
        }
        

        public void EditTitle()
        {
            
            TitleField.Clear();
            TitleField.SendKeys("TestArticle12345-EditTitle");
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

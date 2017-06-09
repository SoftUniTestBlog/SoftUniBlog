using ProjectTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProjectTests.Pages.CreatePage
{
    public partial class CreatePage : BasePage
    {
       
        
        public CreatePage(IWebDriver driver) : base(driver)
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
          Driver.Navigate().GoToUrl(this.url + "/Article/Create");
        }


        public void LogOffClick()
        {
            LogoffButton.Click();
        }

        public void ManageClick()
        {
            ManageButton.Click();
        }

        public void FillTitleContent(string title,string content)
        {
            TitleField.Clear();
            TitleField.SendKeys(title);
            ContentField.Clear();
            ContentField.SendKeys(content);
            CreateButton.Click();
        }

        public void ClickCancelButton()
        {
           CancelButton.Click();
        }
    }
}

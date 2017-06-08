using BasicFunctionality.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BasicFunctionality.Pages.UserListPage
{
    public partial class UserListPage : BasePage
    {
        private List<IWebElement> deletefields = new List<IWebElement>();

        public UserListPage(IWebDriver driver) : base(driver)
        {
        }



        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.url + "/User/List");
        }

        public void LogIn()
        {
            NavigateToHomePage();
            LoginButton.Click();
            EmailFieldLogin.Clear();
            EmailFieldLogin.SendKeys("admin@admin.com");
            PasswordFieldLogin.Clear();
            PasswordFieldLogin.SendKeys("123");
            LoginSubmitButton.Click();

        }
       

        public void Delete()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements[i].Click();
                if ((UserNameField.GetAttribute("value") != "admin@admin.com"))
                {
                    DeleteButton.Click();
                    i=-1;
                }
                else
                {
                    CancelButton.Click();
                    
                }
                
            }
        }

        public void DeleteTestUser()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements[i].Click();
                if ((UserNameField.GetAttribute("value") == "test@test.test"))
                {
                    DeleteButton.Click();
                    i = -1;
                }
                else
                {
                    CancelButton.Click();

                }

            }
        }



    }
}

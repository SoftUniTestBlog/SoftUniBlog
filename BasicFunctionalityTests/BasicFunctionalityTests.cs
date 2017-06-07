using DesignPattern.Pages.ArticleDeletePage;
using DesignPattern.Pages.ArticleDetailsPage;
using DesignPattern.Pages.ArticleEditPage;
using DesignPattern.Pages.ChangePasswordPage;
using DesignPattern.Pages.CreatePage;
using DesignPattern.Pages.LoginPage;
using DesignPattern.Pages.ManagePage;
using DesignPattern.Pages.RegistrationPage;
using DesignPattern.Pages.UserListPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectTests.Pages.HomePage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace BasicFunctionalityTests
{
    class BasicFunctionalityTests
    {
        private IWebDriver driver = BrowserHost.Instance.Application.Browser;

        [SetUp]
        public void Init()
        {
            //Thread.Sleep(30000);
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
            var logo = wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var relative = System.AppDomain.CurrentDomain.BaseDirectory;
                string filename = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(relative + filename))
                {
                    File.Delete(relative + filename);
                }
                File.WriteAllText(relative+ filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(relative + filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
                
            }
            driver.Quit();
        }

        //Login with correct credentials
        [Test, Order(2)]
        public void LoginWithCorrectCredentials()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.Login();
            loginPage.AssertSuccesfullLogin();
        }

        //Login without email
        [Test, Order(3)]
        public void LoginWithOutEmail()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillPassword();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertLoginEmailIsEntered();
        }

        //Login with incorrect email
        [Test, Order(4)]
        public void LoginWithIncorrectEmail()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillIncorrectEmail();
            loginPage.FillPassword();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertLoginEmailIsIncorrect();
        }

        //Login without password
        [Test, Order(5)]
        public void LoginWithOutPassword()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillEmail();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertLoginPasswordIsEntered();
        }

        //Login with incorrect password
        [Test, Order(6)]
        public void LoginWithIncorrectPassword()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillEmail();
            loginPage.FillIncorrectPassword();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertLoginPasswordIsIncorrect();
        }

        [Test, Order(1)]
        public void CreateArticleWithTitleAndContent()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("TestArticle12345", "asddd");
            createPage.AssertYouSeeArticle();

        }

        [Test, Order(7)]
        public void CreateArticleWithoutTitle()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("", "TestWithoutTitle");
            createPage.AssertYouSeeTitleError();
        }

        [Test, Order(8)]
        public void CreateArticleWithoutContent()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("TestWithoutContent", "");
            createPage.AssertYouSeeContentError();
        }

        [Test, Order(9)]
        public void CreateArticleWithTitleMoreThanFifthyCharacters()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd", "asd");
            createPage.AssertYouSeeCharactersError();
        }

        [Test, Order(10)]
        public void CancelCreateArticle()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.ClickCancelButton();
            createPage.AssertYouAreOnArticleListPage();
        }

        // User List Page

        [Test, Order(25)]
        public void DeleteUsers()
        {
            var userListPage = new UserListPage(driver);
            userListPage.LogIn();
            userListPage.NavigateTo();
            userListPage.Delete();

        }

        //Create User
        [Test, Order(0)]
        public void ACreateTestUserTest()
        {
            var changePasswordPage = new ChangePasswordPage(driver);

            changePasswordPage.Register();
        }


        //Enter an incorrect current password
        [Test, Order(12)]
        public void EnterIncorrectCurrentPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);

            changePasswordPage.LogIn();
            changePasswordPage.EnterIncorrectCurrentPasswordChange();
            changePasswordPage.AssertCurrentPasswordIsIncorrect();
        }

        //Do not anter a new password
        [Test, Order(13)]
        public void EnterEmptyNewPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.EnterIncorrectCurrentPasswordChange();
            changePasswordPage.AssertCurrentPasswordIsIncorrect();

        }

        //Do not enter a confirm password
        [Test, Order(14)]
        public void EnterEmptyConfirmNewPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.EnterEmptyConfirmPassword();
            changePasswordPage.AssertConfirmPasswordIsEntered();

        }

        //Enter mismathching new password
        [Test, Order(15)]
        public void EnterMissmatchingNewPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.EnterMissmatchingNewPassword();
            changePasswordPage.AssertEnteredPasswordsAreMissmatching();

        }

        [Test, Order(16), Property("Register without", 0)]
        public void RegisterWithOutEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.FillFullName();
            registrationPage.FillPassword();
            registrationPage.FillConfirmPassword();
            registrationPage.ClickRegisterButtonSubmit();
            registrationPage.AssertEmailIsEntered();
        }

        //Register with incorrect email
        [Test, Order(17)]
        public void RegisterWithIncorrectEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.FillIncorrectEmail();
            registrationPage.FillFullName();
            registrationPage.FillPassword();
            registrationPage.FillConfirmPassword();
            registrationPage.ClickRegisterButtonSubmit();
            registrationPage.AssertIncorrectEmailIsEntered();
        }

        //Register without full name
        [Test, Order(18), Property("Register without", 0)]
        public void RegisterWithOutFullName()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.FillEmail();
            registrationPage.FillPassword();
            registrationPage.FillConfirmPassword();
            registrationPage.ClickRegisterButtonSubmit();
            registrationPage.AssertFullNameIsEntered();
        }

        //Register without password
        [Test, Order(19), Property("Register without",0)]
        public void RegisterWithOutPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.FillEmail();
            registrationPage.FillFullName();
            registrationPage.FillConfirmPassword();
            registrationPage.ClickRegisterButtonSubmit();
            registrationPage.AssertPasswordIsEntered();

        }

        //Register without confirm password
        [Test, Order(20), Property("Register without", 0)]
        public void RegisterWithOutConfirmPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.FillEmail();
            registrationPage.FillFullName();
            registrationPage.FillPassword();
            registrationPage.ClickRegisterButtonSubmit();
            registrationPage.AssertConfirmPasswordIsEntered();
        }

        //Register password missmatch
        [Test, Order(21)]
        public void RegisterPasswordMissmatch()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.FillEmail();
            registrationPage.FillFullName();
            registrationPage.FillPassword();
            registrationPage.FillConfirmPasswordMissmatch();
            registrationPage.ClickRegisterButtonSubmit();
            registrationPage.AssertPasswordMatch();
        }

        // ArticleEditPage
        [Test, Order(22)]
        public void CheckIfTitleIsEditableInArticleEditMode()
        {
            var articleEditPage = new ArticleEditPage(driver);
            articleEditPage.LogIn();
            articleEditPage.NavigateTo();
            articleEditPage.EditTitle();
            articleEditPage.AssertChangedTitle();
        }

        [Test, Order(23)]
        public void CheckIfContentIsEditableInArticleEditMode()
        {
            var articleEditPage = new ArticleEditPage(driver);
            articleEditPage.LogIn();
            articleEditPage.NavigateTo();
            articleEditPage.EditContent("Edit content");
            articleEditPage.EditButtonClick();
            articleEditPage.AssertChangedContent();
        }

        [Test, Order(24)]
        public void CheckIfDeleteButtonInArticleDeleteModeIsWorking()
        {
            var articleDeletePage = new ArticleDeletePage(driver);
            articleDeletePage.LogIn();
            articleDeletePage.NavigateTo();
            articleDeletePage.DeleteButtonClick();
            articleDeletePage.AssertArticleIsDeleted();
        }

    }
}

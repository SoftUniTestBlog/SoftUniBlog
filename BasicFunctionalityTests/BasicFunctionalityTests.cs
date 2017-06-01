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


namespace BasicFunctionalityTests
{
    class BasicFunctionalityTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
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
        [Test]
        public void LoginWithCorrectCredentials()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.Login();
            loginPage.AssertSuccesfullLogin();
        }

        //Login without email
        [Test]
        public void LoginWithOutEmail()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillPassword();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertLoginEmailIsEntered();
        }

        //Login with incorrect email
        [Test]
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
        [Test]
        public void LoginWithOutPassword()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillEmail();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertLoginPasswordIsEntered();
        }

        //Login with incorrect password
        [Test]
        public void LoginWithIncorrectPassword()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillEmail();
            loginPage.FillIncorrectPassword();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertLoginPasswordIsIncorrect();
        }

        [Test]
        public void CreateArticleWithTitleAndContent()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("TestArticle12345", "asddd");
            createPage.AssertYouSeeArticle();

        }

        [Test]
        public void CreateArticleWithoutTitle()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("", "TestWithoutTitle");
            createPage.AssertYouSeeTitleError();
        }

        [Test]
        public void CreateArticleWithoutContent()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("TestWithoutContent", "");
            createPage.AssertYouSeeContentError();
        }

        [Test]
        public void CreateArticleWithTitleMoreThanFifthyCharacters()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd", "asd");
            createPage.AssertYouSeeCharactersError();
        }

        [Test]
        public void CancelCreateArticle()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.ClickCancelButton();
            createPage.AssertYouAreOnArticleListPage();
        }

        // User List Page

        [Test]
        public void DeleteUsers()
        {
            var userListPage = new UserListPage(driver);
            userListPage.LogIn();
            userListPage.NavigateTo();
            userListPage.Delete();

        }

        //Create User
        [Test]
        public void ACreateTestUserTest()
        {
            var changePasswordPage = new ChangePasswordPage(driver);

            changePasswordPage.Register();
        }


        //Enter an incorrect current password
        [Test]
        public void EnterIncorrectCurrentPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);

            changePasswordPage.LogIn();
            changePasswordPage.EnterIncorrectCurrentPasswordChange();
            changePasswordPage.AssertCurrentPasswordIsIncorrect();
        }

        //Do not anter a new password
        [Test]
        public void EnterEmptyNewPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.EnterIncorrectCurrentPasswordChange();
            changePasswordPage.AssertCurrentPasswordIsIncorrect();

        }

        //Do not enter a confirm password
        [Test]
        public void EnterEmptyConfirmNewPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.EnterEmptyConfirmPassword();
            changePasswordPage.AssertConfirmPasswordIsEntered();

        }

        //Enter mismathching new password
        [Test]
        public void EnterMissmatchingNewPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.EnterMissmatchingNewPassword();
            changePasswordPage.AssertEnteredPasswordsAreMissmatching();

        }

        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
        public void CheckIfTitleIsEditableInArticleEditMode()
        {
            var articleEditPage = new ArticleEditPage(driver);
            articleEditPage.LogIn();
            articleEditPage.NavigateTo();
            articleEditPage.EditTitle();
            articleEditPage.AssertChangedTitle();
        }

        [Test]
        public void CheckIfContentIsEditableInArticleEditMode()
        {
            var articleEditPage = new ArticleEditPage(driver);
            articleEditPage.LogIn();
            articleEditPage.NavigateTo();
            articleEditPage.EditContent("Edit content");
            articleEditPage.EditButtonClick();
            articleEditPage.AssertChangedContent();
        }

    }
}

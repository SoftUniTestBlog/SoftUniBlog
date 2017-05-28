using DesignPattern.Pages.ArticleDeletePage;
using DesignPattern.Pages.ArticleDetailsPage;
using DesignPattern.Pages.ArticleEditPage;
using DesignPattern.Pages.CreatePage;
using DesignPattern.Pages.LoginPage;
using DesignPattern.Pages.ManagePage;
using DesignPattern.Pages.RegistrationPage;
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


namespace ProjectTests
{
    class GeneralProjectTests
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

        //FIRSTCOMMIT


        //Check if I am located on the Home Page
        [Test]
        [Property("HomePage", "1")]
        public void CheckIfYouAreOnHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            homePage.AssertYouAreOnHomePage("SOFTUNI BLOG");

        }

        //Check if SoftUni Blog Button is working on home page
        [Test]
        [Property("HomePage", "1")]
        public void CheckIfSoftUniBlogButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            homePage.AssertCopyrightIsPresent();

        }

        //Check if Register Button is working
        [Test]
        public void CheckIfRegisterButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.ClickRegisterButton();
            homePage.AssertYouAreOnRegistrationPage("Register");

        }

        //Check if Log In button works
        [Test]
        public void CheckIfLoginButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.ClickLogInButton();
            homePage.AssertYouAreOnRegistrationPage("Log in");

        }

        //Check if "© 2017 - SoftUni Blog" is present on HomePage
        [Test]
        public void CheckIf2017SoftUniBlogTextIsPresentHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            homePage.AssertCopyrightIsPresent();

        }


        //Second Commit
        //Check if create button is working from Home Page
        [Test]
        public void CheckIfCreateButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.LogInAndClickCreateButton();
            homePage.AssertIAmOnCreatePage();
        }

        //Check if Log off button is working
        [Test]
        public void CheckIfLogOffButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.LogInAndOut();
            homePage.AssertLogOffButtonIsWorking();
        }

        //Check if Log off button is working
        [Test]
        public void CheckIfManageUserButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.LogInAndClickManageButton();
            homePage.AssertManageButtonIsWorkingOnHomePage();
        }

        //Check if when Logged off the Create button is not displayed 
        [Test]
        public void CheckIfCreateButtonIsNotDisplayedHomePageWhenYouAreNotLoggedIn()
        {
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            homePage.AssertCreateButtonIsMissing();
        }

        //Manage Page Tests
        //Check if Soft Uni Blog button is working when you are on Manage Page
        [Test]
        public void CheckIfSoftUniBlogButtonIsWorkingManagePage()
        {
            var managePage = new ManagePage(driver);
            managePage.NavigateToAndClickSoftUniBlogButton();
            managePage.AssertYouAreOnHomePage();
        }

        //Check if Soft Uni copyright text is on Manage Page
        [Test]
        public void CheckIfCopyrightoftUniBlogTextIsPresentManagePage()
        {
            var managePage = new ManagePage(driver);
            managePage.NavigateTo();
            managePage.AssertCopyrightIsPresent();
        }

        //Check if Create button is working on Manage Page
        [Test]
        public void CheckIfCreateButtonIsWorkingManagePage()
        {
            var managePage = new ManagePage(driver);
            managePage.ClickCreateButton();
            managePage.AssertIAmOnCreatePage();
        }

        //dilyan
        //Create page

        [Test]
        public void CheckIfLogOffButtonIsWorkingCreatePage()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.LogOffClick();
            createPage.AssertYouSeeLogInButton();
        }

        [Test]
        public void CheckIfManageUserButtonIsWorkingCreatePage()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.ManageClick();
            createPage.AssertYouSeePassword();
        }

        [Test]
        public void CreateArticleWithTitleAndContent()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("TestArticle12345", "asddd");
            createPage.AssertYouSeeArticle();
            createPage.GetId();
        }

        [Test]
        public void CreateArticleWithoutTitle()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("","TestWithoutTitle");
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

        //Article tests with logged in user:
        //ArticleDetailsPage
        [Test]
        public void CheckIfEditButtonInArticleIsWorking()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickEditButton();
            articleDetailsPage.AssertYouAreOnEditPage();
        }

        [Test]
        public void CheckIfBackButtonInArticleWorking()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickBackButton();
            articleDetailsPage.AssertYouAreOnListPage();
        }

        [Test]
        public void CheckIfCreateButtonIsWorkingArticlePage()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickCreateButton();
            articleDetailsPage.AssertYouAreOnCreatePage();
        }

        [Test]
        public void CheckIfLogOffButtonIsWorkingArticlePage()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickLogOffButton();
            articleDetailsPage.AssertYouAreNotLogged();
        }

        [Test]
        public void CheckIfManageUserButtonIsWorkingArticlePage()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickManageButton();
            articleDetailsPage.AssertYouAreOnManagePage();
        }

        [Test]
        public void CheckIfErrorMessageIsDisplayedTryingToEditArticleCreatedFromAnotherUser()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.ClickLogOffButton();
            articleDetailsPage.RegisterSecondUser();
            articleDetailsPage.LogInSecondUser();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickEditButton();
            articleDetailsPage.AssertYouHaveNoPermissions();
            
         }

        [Test]
        public void CheckIfErrorMessageIsDisplayedTryingToDeleteArticleCreatedFromAnotherUser()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
         
            articleDetailsPage.LogInSecondUser();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickDeleteButton();
            articleDetailsPage.AssertYouHaveNoPermissions();

        }

        //Check if Create button is notpresent when logged out on Article Details view
        [Test]
        public void CheckIfCreateButtonIsNotDisplyedArticlePage()
        {
            var articleNodeView = new ArticleDetailsPage(driver);
            articleNodeView.NavigateToFirstArticle();
            articleNodeView.AssertCreateButtonIsMissing();
        }

        //Check if Login button is working on Article Details view page
        [Test]
        public void CheckIfEditButtonInArticleIsRedirectingToLoginPage()
        {
            var articleNodeView = new ArticleDetailsPage(driver);
            articleNodeView.NavigateToFirstArticle();
            articleNodeView.ClickLoginButton();
            articleNodeView.AssertYouAreOnLoginPage("Log in");
        }

        //Check if SoftUni Blog button is working on Article Details view page
        [Test]
        public void CheckIfSoftUniBlogButtonIsWorkingArticlePage()
        {
            var articleNodeView = new ArticleDetailsPage(driver);
            articleNodeView.NavigateToFirstArticle();
            articleNodeView.ClickSoftuniBlogButton();
            articleNodeView.AssertYouAreOnHomePage("SOFTUNI BLOG");
        }

        //Check if SoftUni Blog button is working on Article Details view page
        [Test]
        public void CheckIf2017SoftUniBlogTextIsPresentArticlePage()
        {
            var articleNodeView = new ArticleDetailsPage(driver);
            articleNodeView.NavigateToFirstArticle();
            articleNodeView.ClickSoftuniBlogButton();
            articleNodeView.AssertYouAreOnHomePage("SOFTUNI BLOG");
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

        [Test]
        public void CheckIfCancelButtonInArticleEditModeIsWorking()
        {
            var articleEditPage = new ArticleEditPage(driver);
            articleEditPage.LogIn();
            articleEditPage.NavigateTo();
            articleEditPage.EditContent("This should not be visible");
            articleEditPage.CancelButtonClick();
            articleEditPage.AssertCancel();
        }

        // ArticleDeletePage

        [Test]
        public void CheckIfTitleIsEditableInArticleDeleteModearticle()
        {
            var articleDeletePage = new ArticleDeletePage(driver);
            articleDeletePage.LogIn();
            articleDeletePage.NavigateTo();
            articleDeletePage.EditTitle();
            articleDeletePage.AssertTitleIsNotChanged();
        }

        [Test]
        public void CheckIfContentIsEditableInArticleDeleteMode()
        {
            var articleDeletePage = new ArticleDeletePage(driver);
            articleDeletePage.LogIn();
            articleDeletePage.NavigateTo();
            articleDeletePage.EditContent();
            articleDeletePage.AssertContentIsNotChanged();
        }

        [Test]
        public void CheckIfCancelButtonInArticleDeleteModeIsWorking()
        {
            var articleDeletePage = new ArticleDeletePage(driver);
            articleDeletePage.LogIn();
            articleDeletePage.NavigateTo();
            articleDeletePage.CancelButtonClick();
            articleDeletePage.AssertYouAreOnListPage();
        }

        // [Test]
        // public void CheckIfCancelButtonInArticleDeleteModeIsWorking()
        // {
        //    var articleDeletePage = new ArticleDeletePage(driver);
        //   articleDeletePage.LogIn();
        //  articleDeletePage.NavigateTo();
        //  articleDeletePage.DeleteButtonClick();
        // articleDeletePage.AssertArticleIsDeleted();
        //   }

        //Registration page tests by Tsvetomir Pavlov
        //Register with correct credentials
        [Test]
        public void RegisterWithCorrectCredentials()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.Register();
            registrationPage.AssertSuccessRegistration();
        }

        //Register without email
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

        //Check if "Register" submit button is working on register page
        [Test]
        public void CheckIfLoginSubmitButtonIsWorkingResgisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.Register();
            registrationPage.AssertSuccessRegistration();
        }

        //Check if "SoftUniBlog" button is working on register page
        [Test]
        public void CheckIfSoftUniBlogButtonIsWorkingRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.ClickSoftUniBlogButton();
            registrationPage.AssertSoftUniBlogButtonIsWorking();
        }

        //Check if "Login" button is working on register page
        [Test]
        public void CheckIfLoginButtonIsWorkingRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.ClickLoginButton();
            registrationPage.AssertLoginButtonIsWorking();
        }

        //Check if "Register" button is working on register page
        [Test]
        public void CheckIfRegisterButtonIsWorkingRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.ClickRegisterButton();
            registrationPage.AssertRegisterButtonIsWorking();
        }

        //Check if "©2017SoftUniBlog" text is present on register page
        [Test]
        public void CheckIf2017SoftUniBlogTextIsPresentRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.AssertCopyrightIsPresent();
        }


        //Check if "Create" button is not displayed on register page
        [Test]
        public void CheckIfCreateButtonIsNotDisplyedRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.AssertCreateButtonIsNotPresent();
        }
        //Login page tests by Tsvetomir Pavlov
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

        //Check if "Login" submit button is working on login page
        [Test]
        public void CheckIfLoginSubmitButtonIsWorkingLoginPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.Login();
            loginPage.AssertSuccesfullLogin();
        }

        //Check if "©2017SoftUniBlog" text is present in login page
        [Test]
        public void CheckIf2017SoftUniBlogTextIsPresentLogInPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.AssertCopyrightIsPresent();
        }

        //Check if "Login" button is working on login page
        [Test]
        public void CheckIfLoginButtonIsWorkingLoginPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.ClickLoginButton();
            loginPage.AssertLoginButtonIsWorking();
        }

        //Check if "Register" button is working on login page
        [Test]
        public void CheckIfRegisterButtonIsWorkingLoginPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.ClickRegisterButton();
            loginPage.AssertRegisterButtonIsWorking();
        }

        //Check if "Remeber me" checkbox is working on login page 
        [Test]
        public void CheckIfRememberMeCheckBoxIsWorkingLoginPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillEmail();
            loginPage.FillPassword();
            loginPage.SelectCheckbox();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertCheckBoxIsSelected();
        }

        //Check if "SoftUniBlog" button is working on login page 
        [Test]
        public void CheckIfSoftUniBlogButtonIsWorkingLogInPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.ClickSoftUniBlogButton();
            loginPage.AssertSoftUniBlogButtonIsWorking();
        }

        //Check if "Create" button is not displayed on login page 
        [Test]
        public void CheckIfCreateButtonIsNotDisplyedLoginPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.AssertCreateButtonIsNotPresent();
        }
    }
}

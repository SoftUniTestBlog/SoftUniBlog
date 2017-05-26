using DesignPattern.Pages.ArticleDeletePage;
using DesignPattern.Pages.ArticleDetailsPage;
using DesignPattern.Pages.ArticleEditPage;
using DesignPattern.Pages.CreatePage;
using DesignPattern.Pages.ManagePage;
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

        }

        //Register without email
        [Test]
        public void RegisterWithOutEmail()
        {

        }

        //Register with incorrect email
        [Test]
        public void RegisterWithIncorrectEmail()
        {

        }

        //Register without full name
        [Test]
        public void RegisterWithOutFullName()
        {

        }

        //Register without password
        [Test]
        public void RegisterWithOutPassworde()
        {

        }

        //Register without confirm password
        [Test]
        public void RegisterWithOutConfirmPassword()
        {

        }

        //Register password missmatch
        [Test]
        public void RegisterPasswordMissmatch()
        {

        }

        //Check if "SoftUniBlog" button is working on register page
        [Test]
        public void CheckIfSoftUniBlogButtonIsWorkingRegisterPage()
        {

        }

        //Check if "Login" button is working on register page
        [Test]
        public void CheckIfLoginButtonIsWorkingResgisterPage()
        {

        }

        //Check if "©2017SoftUniBlog" text is present on register page
        [Test]
        public void CheckIf2017SoftUniBlogTextIsPresentRegisterPage()
        {

        }

        //Check if "Register" button is working on register page
        [Test]
        public void CheckIfRegisterButtonIsWorkingRegisterPage()
        {

        }

        //Check if "Create" button is not displayed on register page
        [Test]
        public void CheckIfCreateButtonIsNotDisplyedRegisterPage()
        {

        }

        //Login page tests by Tsvetomir Pavlov
        //Login with correct credentials
        [Test]
        public void LoginWithCorrectCredentials()
        {

        }

        //Login without email
        [Test]
        public void LoginWithOutEmail()
        {

        }

        //Login with incorrect email
        [Test]
        public void LoginWithIncorrectEmail()
        {

        }

        //Login without password
        [Test]
        public void LoginWithOutPassword()
        {

        }

        //Login with incorrect password
        [Test]
        public void LoginWithIncorrectPassword()
        {

        }

        //Check if "©2017SoftUniBlog" text is present in login page
        [Test]
        public void CheckIf2017SoftUniBlogTextIsPresentLogInPage()
        {

        }

        //Check if "Login" button is working on login page
        [Test]
        public void CheckIfLoginButtonIsWorkingLoginPage()
        {

        }

        //Check if "Remeber me" checkbox is working on login page 
        [Test]
        public void CheckIfRememberMeCheckBoxIsWorkingLoginPage()
        {

        }

        //Check if "SoftUniBlog" button is working on login page 
        [Test]
        public void CheckIfSoftUniBlogButtonIsWorkingLogInPage()
        {

        }

        //Check if "Create" button is not displayed on login page 
        [Test]
        public void CheckIfCreateButtonIsNotDisplyedLoginPage()
        {

        }
    }
}

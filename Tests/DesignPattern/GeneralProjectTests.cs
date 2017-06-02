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
                File.WriteAllText(relative + filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(relative + filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);

            }
            driver.Quit();
        }

        //FIRSTCOMMIT


        //Check if I am located on the Home Page
        [Test, Order(10)]

        public void CheckIfYouAreOnHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            homePage.AssertYouAreOnHomePage("SOFTUNI BLOG");

        }

        //Check if SoftUni Blog Button is working on home page
        [Test, Order(2)]

        public void CheckIfSoftUniBlogButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            homePage.AssertCopyrightIsPresent();

        }

        //Check if Register Button is working
        [Test, Order(3)]
        public void CheckIfRegisterButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.ClickRegisterButton();
            homePage.AssertYouAreOnRegistrationPage("Register");

        }

        //Check if Log In button works
        [Test, Order(4)]
        public void CheckIfLoginButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.ClickLogInButton();
            homePage.AssertYouAreOnRegistrationPage("Log in");

        }

        //Check if "© 2017 - SoftUni Blog" is present on HomePage
        [Test, Order(5)]
        public void CheckIf2017SoftUniBlogTextIsPresentHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            homePage.AssertCopyrightIsPresent();

        }



        //Check if create button is working from Home Page
        [Test, Order(6)]
        public void CheckIfCreateButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.LogInAndClickCreateButton();
            homePage.AssertIAmOnCreatePage();
        }

        //Check if Log off button is working
        [Test, Order(7)]
        public void CheckIfLogOffButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.LogInAndOut();
            homePage.AssertLogOffButtonIsWorking();
        }

        //Check if Log off button is working
        [Test, Order(8)]
        public void CheckIfManageUserButtonIsWorkingHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.LogInAndClickManageButton();
            homePage.AssertManageButtonIsWorkingOnHomePage();
        }

        //Check if when Logged off the Create button is not displayed 
        [Test, Order(9)]
        public void CheckIfCreateButtonIsNotDisplayedHomePageWhenYouAreNotLoggedIn()
        {
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            homePage.AssertCreateButtonIsMissing();
        }


        //ChangeUserPasswordTests

        //Create User
        [Test, Order(1)]
        public void ACreateTestUserTest()
        {
            var changePasswordPage = new ChangePasswordPage(driver);

            changePasswordPage.Register();
        }


        //Enter an incorrect current password
        [Test, Order(11)]
        public void EnterIncorrectCurrentPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);

            changePasswordPage.LogIn();
            changePasswordPage.EnterIncorrectCurrentPasswordChange();
            changePasswordPage.AssertCurrentPasswordIsIncorrect();
        }

        //Do not anter a new password
        [Test, Order(12)]
        public void EnterEmptyNewPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.EnterIncorrectCurrentPasswordChange();
            changePasswordPage.AssertCurrentPasswordIsIncorrect();

        }

        //Do not enter a confirm password
        [Test, Order(13)]
        public void EnterEmptyConfirmNewPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.EnterEmptyConfirmPassword();
            changePasswordPage.AssertConfirmPasswordIsEntered();

        }

        //Enter mismathching new password
        [Test, Order(14)]
        public void EnterMissmatchingNewPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.EnterMissmatchingNewPassword();
            changePasswordPage.AssertEnteredPasswordsAreMissmatching();

        }

        //Check if change password button is working
        [Test, Order(15)]
        public void CheckIfChangeYourPasswordButtonIsWorkingManagePage()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.ClickChangePasswordButton();
            changePasswordPage.AssertButtonIsWorking1();
            changePasswordPage.AssertButtonIsWorking2();
        }

        //Check if change password button is working
        [Test, Order(71)]
        public void SuccessfullPasswordChange()
        {
            var changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.LogIn();
            changePasswordPage.SuccessfullPasswordChange();
            changePasswordPage.AssertChangePasswordIsSuccessfull();
        }

        //DeleteUserWithChangedPassword
        [Test, Order(72)]
        public void WDeleteTestUser()
        {
            var userListPage = new UserListPage(driver);
            userListPage.LogIn();
            userListPage.NavigateTo();
            userListPage.DeleteTestUser();
        }



        //Manage Page Tests
        //Check if Soft Uni Blog button is working when you are on Manage Page
        [Test, Order(16)]
        public void CheckIfSoftUniBlogButtonIsWorkingManagePage()
        {
            var managePage = new ManagePage(driver);
            managePage.NavigateToAndClickSoftUniBlogButton();
            managePage.AssertYouAreOnHomePage();
        }

        //Check if Soft Uni copyright text is on Manage Page
        [Test, Order(17)]
        public void CheckIfCopyrightoftUniBlogTextIsPresentManagePage()
        {
            var managePage = new ManagePage(driver);
            managePage.NavigateTo();
            managePage.AssertCopyrightIsPresent();
        }

        //Check if Create button is working on Manage Page
        [Test, Order(18)]
        public void CheckIfCreateButtonIsWorkingManagePage()
        {
            var managePage = new ManagePage(driver);
            managePage.ClickCreateButton();
            managePage.AssertIAmOnCreatePage();
        }

        //Check if Log Off button is working on Manage Page
        [Test, Order(19)]
        public void CheckIfLogOffButtonIsWorkingManagePage()
        {
            var managePage = new ManagePage(driver);
            managePage.NavigateTo();
            managePage.ClickLogOffButton();
            managePage.AssertIAmLoggedOff();
        }


        //dilyan
        //Create page

        [Test, Order(20)]
        public void CheckIfLogOffButtonIsWorkingCreatePage()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.LogOffClick();
            createPage.AssertYouSeeLogInButton();
        }

        [Test, Order(21)]
        public void CheckIfManageUserButtonIsWorkingCreatePage()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.ManageClick();
            createPage.AssertYouSeePassword();
        }

        [Test, Order(22)]
        public void CreateArticleWithTitleAndContent()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("TestArticle12345", "asddd");
            createPage.AssertYouSeeArticle();

        }

        [Test, Order(23)]
        public void CreateArticleWithoutTitle()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("", "TestWithoutTitle");
            createPage.AssertYouSeeTitleError();
        }

        [Test, Order(24)]
        public void CreateArticleWithoutContent()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("TestWithoutContent", "");
            createPage.AssertYouSeeContentError();
        }

        [Test, Order(25)]
        public void CreateArticleWithTitleMoreThanFifthyCharacters()
        {
            var createPage = new CreatePage(driver);
            createPage.LogIn();
            createPage.NavigateTo();
            createPage.FillTitleContent("asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd", "asd");
            createPage.AssertYouSeeCharactersError();
        }

        [Test, Order(26)]
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
        [Test, Order(27)]
        public void CheckIfEditButtonInArticleIsWorking()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickEditButton();
            articleDetailsPage.AssertYouAreOnEditPage();
        }

        [Test, Order(28)]
        public void CheckIfBackButtonInArticleWorking()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickBackButton();
            articleDetailsPage.AssertYouAreOnListPage();
        }

        [Test, Order(29)]
        public void CheckIfCreateButtonIsWorkingArticlePage()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickCreateButton();
            articleDetailsPage.AssertYouAreOnCreatePage();
        }

        [Test, Order(30)]
        public void CheckIfLogOffButtonIsWorkingArticlePage()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickLogOffButton();
            articleDetailsPage.AssertYouAreNotLogged();
        }

        [Test, Order(31)]
        public void CheckIfManageUserButtonIsWorkingArticlePage()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickManageButton();
            articleDetailsPage.AssertYouAreOnManagePage();
        }

        [Test, Order(32)]
        public void CheckIfErrorMessageIsDisplayedTryingToEditArticleCreatedFromAnotherUser()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);
            articleDetailsPage.LogIn();
            articleDetailsPage.ClickLogOffButton();
            articleDetailsPage.RegisterSecondUser();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickEditButton();
            articleDetailsPage.AssertYouHaveNoPermissions();

        }

        [Test, Order(33)]
        public void CheckIfErrorMessageIsDisplayedTryingToDeleteArticleCreatedFromAnotherUser()
        {
            var articleDetailsPage = new ArticleDetailsPage(driver);

            articleDetailsPage.LogInSecondUser();
            articleDetailsPage.NavigateTo();
            articleDetailsPage.ClickDeleteButton();
            articleDetailsPage.AssertYouHaveNoPermissions();

        }

        //Check if Create button is notpresent when logged out on Article Details view
        [Test, Order(34)]
        public void CheckIfCreateButtonIsNotDisplyedArticlePage()
        {
            var articleNodeView = new ArticleDetailsPage(driver);
            articleNodeView.NavigateToFirstArticle();
            articleNodeView.AssertCreateButtonIsMissing();
        }

        //Check if Login button is working on Article Details view page
        [Test, Order(35)]
        public void CheckIfEditButtonInArticleIsRedirectingToLoginPage()
        {
            var articleNodeView = new ArticleDetailsPage(driver);
            articleNodeView.NavigateToFirstArticle();
            articleNodeView.ClickLoginButton();
            articleNodeView.AssertYouAreOnLoginPage("Log in");
        }

        //Check if SoftUni Blog button is working on Article Details view page
        [Test, Order(36)]
        public void CheckIfSoftUniBlogButtonIsWorkingArticlePage()
        {
            var articleNodeView = new ArticleDetailsPage(driver);
            articleNodeView.NavigateToFirstArticle();
            articleNodeView.ClickSoftuniBlogButton();
            articleNodeView.AssertYouAreOnHomePage("SOFTUNI BLOG");
        }

        //Check if SoftUni Blog button is working on Article Details view page
        [Test, Order(37)]
        public void CheckIf2017SoftUniBlogTextIsPresentArticlePage()
        {
            var articleNodeView = new ArticleDetailsPage(driver);
            articleNodeView.NavigateToFirstArticle();
            articleNodeView.ClickSoftuniBlogButton();
            articleNodeView.AssertYouAreOnHomePage("SOFTUNI BLOG");
        }


        // ArticleEditPage
        [Test, Order(38)]
        public void CheckIfTitleIsEditableInArticleEditMode()
        {
            var articleEditPage = new ArticleEditPage(driver);
            articleEditPage.LogIn();
            articleEditPage.NavigateTo();
            articleEditPage.EditTitle();
            articleEditPage.AssertChangedTitle();
        }

        [Test, Order(39)]
        public void CheckIfContentIsEditableInArticleEditMode()
        {
            var articleEditPage = new ArticleEditPage(driver);
            articleEditPage.LogIn();
            articleEditPage.NavigateTo();
            articleEditPage.EditContent("Edit content");
            articleEditPage.EditButtonClick();
            articleEditPage.AssertChangedContent();
        }

        [Test, Order(40)]
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

        [Test, Order(41)]
        public void CheckIfTitleIsEditableInArticleDeleteModearticle()
        {
            var articleDeletePage = new ArticleDeletePage(driver);
            articleDeletePage.LogIn();
            articleDeletePage.NavigateTo();
            articleDeletePage.EditTitle();
            articleDeletePage.AssertTitleIsNotChanged();
        }

        [Test, Order(42)]
        public void CheckIfContentIsEditableInArticleDeleteMode()
        {
            var articleDeletePage = new ArticleDeletePage(driver);
            articleDeletePage.LogIn();
            articleDeletePage.NavigateTo();
            articleDeletePage.EditContent();
            articleDeletePage.AssertContentIsNotChanged();
        }

        [Test, Order(43)]
        public void CheckIfCancelButtonInArticleDeleteModeIsWorking()
        {
            var articleDeletePage = new ArticleDeletePage(driver);
            articleDeletePage.LogIn();
            articleDeletePage.NavigateTo();
            articleDeletePage.CancelButtonClick();
            articleDeletePage.AssertYouAreOnListPage();
        }

        [Test, Order(70)]
        public void CheckIfDeleteButtonInArticleDeleteModeIsWorking()
        {
            var articleDeletePage = new ArticleDeletePage(driver);
            articleDeletePage.LogIn();
            articleDeletePage.NavigateTo();
            articleDeletePage.DeleteButtonClick();
            articleDeletePage.AssertArticleIsDeleted();
        }

        // User List Page

        [Test, Order(73)]
        public void DeleteUsers()
        {
            var userListPage = new UserListPage(driver);
            userListPage.LogIn();
            userListPage.NavigateTo();
            userListPage.Delete();

        }



        //Registration page tests by Tsvetomir Pavlov
        //Register with correct credentials
        [Test, Order(45)]
        public void RegisterWithCorrectCredentials()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.Register();
            registrationPage.AssertSuccessRegistration();
        }

        //Register without email
        [Test, Order(46)]
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
        [Test, Order(47)]
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
        [Test, Order(48)]
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
        [Test, Order(49)]
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
        [Test, Order(50)]
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
        [Test, Order(51)]
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

        

        //Check if "SoftUniBlog" button is working on register page
        [Test, Order(53)]
        public void CheckIfSoftUniBlogButtonIsWorkingRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.ClickSoftUniBlogButton();
            registrationPage.AssertSoftUniBlogButtonIsWorking();
        }

        //Check if "Login" button is working on register page
        [Test, Order(54)]
        public void CheckIfLoginButtonIsWorkingRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.ClickLoginButton();
            registrationPage.AssertLoginButtonIsWorking();
        }

        //Check if "Register" button is working on register page
        [Test, Order(55)]
        public void CheckIfRegisterButtonIsWorkingRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.ClickRegisterButton();
            registrationPage.AssertRegisterButtonIsWorking();
        }

        //Check if "©2017SoftUniBlog" text is present on register page
        [Test, Order(56)]
        public void CheckIf2017SoftUniBlogTextIsPresentRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.AssertCopyrightIsPresent();
        }


        //Check if "Create" button is not displayed on register page
        [Test, Order(57)]
        public void CheckIfCreateButtonIsNotDisplyedRegisterPage()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.AssertCreateButtonIsNotPresent();
        }
        //Login page tests by Tsvetomir Pavlov
        //Login with correct credentials
        [Test, Order(58)]
        public void LoginWithCorrectCredentials()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.Login();
            loginPage.AssertSuccesfullLogin();
        }

        //Login without email
        [Test, Order(59)]
        public void LoginWithOutEmail()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillPassword();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertLoginEmailIsEntered();
        }

        //Login with incorrect email
        [Test, Order(60)]
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
        [Test, Order(61)]
        public void LoginWithOutPassword()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.FillEmail();
            loginPage.ClickLoginButtonSubmit();
            loginPage.AssertLoginPasswordIsEntered();
        }

        //Login with incorrect password
        [Test, Order(62)]
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
        [Test, Order(63)]
        public void CheckIfLoginSubmitButtonIsWorkingLoginPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.Login();
            loginPage.AssertSuccesfullLogin();
        }

        //Check if "©2017SoftUniBlog" text is present in login page
        [Test, Order(64)]
        public void CheckIf2017SoftUniBlogTextIsPresentLogInPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.AssertCopyrightIsPresent();
        }

        //Check if "Login" button is working on login page
        [Test, Order(65)]
        public void CheckIfLoginButtonIsWorkingLoginPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.ClickLoginButton();
            loginPage.AssertLoginButtonIsWorking();
        }

        //Check if "Register" button is working on login page
        [Test, Order(66)]
        public void CheckIfRegisterButtonIsWorkingLoginPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.ClickRegisterButton();
            loginPage.AssertRegisterButtonIsWorking();
        }

        //Check if "Remeber me" checkbox is working on login page 
        [Test, Order(67)]
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
        [Test, Order(68)]
        public void CheckIfSoftUniBlogButtonIsWorkingLogInPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.ClickSoftUniBlogButton();
            loginPage.AssertSoftUniBlogButtonIsWorking();
        }

        //Check if "Create" button is not displayed on login page 
        [Test, Order(69)]
        public void CheckIfCreateButtonIsNotDisplyedLoginPage()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateTo();
            loginPage.AssertCreateButtonIsNotPresent();
        }
    }
}

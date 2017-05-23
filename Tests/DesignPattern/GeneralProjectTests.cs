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
                string filename = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
                
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
        public void CheckIfSoftUniBlogButtonIsWorkingRegisterPage()
        {
            var homePage = new HomePage(driver);
            homePage.ClickRegisterButton();
            homePage.AssertYouAreOnRegistrationPage("Register");

        }

        //Check if Log In button works
        [Test]
        public void CheckIfSoftUniBlogButtonIsWorkingLogInPage()
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
    }
}

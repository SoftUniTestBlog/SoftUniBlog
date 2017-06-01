using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectTests.Pages.HomePage
{
    public static class HomePageAsserter
    {   //First Commit
        //Check if you are on Registration Page
        public static void AssertYouAreOnRegistrationPage(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.RegisterPageLogo.Text);
        }

        //Check if 
        public static void AssertYouAreOnHomePage(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.Logo.Text);
        }

        //Check if you are on Login Page
        public static void AssertYouAreOnLoginPage(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.LoginPageLogo.Text);
        }

        //Check if copyright is  present
        public static void AssertCopyrightIsPresent(this HomePage page)
        {
            Assert.AreEqual("© 2017 - SoftUni Blog", page.Copyright.Text);
        }

        //Second commit
        //Check if you are on create page 
        public static void AssertIAmOnCreatePage(this HomePage page)
        {
            Assert.AreEqual("Create Article", page.CreatePageLogo.Text);
        }

        //Check if Log off button is working on Home Page
        public static void AssertLogOffButtonIsWorking(this HomePage page)
        {
            Assert.AreEqual("Log in", page.LoginButton.Text);
        }

        //Check if Manage button is working on Home Page
        public static void AssertManageButtonIsWorkingOnHomePage(this HomePage page)
        {
            Assert.AreEqual("Manage", page.ManagePageLogo.Text);
        }

        //Check if Manage button is working on Home Page
        public static void AssertCreateButtonIsMissing(this HomePage page)
        {
            Assert.AreEqual("Register", page.RegistrationButton.Text);
        }
    }
}

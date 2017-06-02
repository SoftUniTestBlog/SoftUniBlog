using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.LoginPage
{
    public static class LoginPageAsserter
    {
        //Login page assertions by Tsvetomir Pavlov
        //Check if login is successfull
        public static void AssertSuccesfullLogin(this LoginPage page)
        {
            Assert.IsTrue(page.HelloMessage.Displayed);
        }
        
        //Check if login email is entered
        public static void AssertLoginEmailIsEntered(this LoginPage page)
        {
            Assert.AreEqual("The Email field is required.", page.EmptyEmail.Text);
        }

        //Check if login email is correct
        public static void AssertLoginEmailIsIncorrect(this LoginPage page)
        {
            Assert.AreEqual("The Email field is not a valid e-mail address.", page.IncorrectEmail.Text);
        }

        //Check if login password is entered
        public static void AssertLoginPasswordIsEntered(this LoginPage page)
        {
            Assert.AreEqual("The Password field is required.", page.EmptyPassword.Text);
        }

        //Check if login password is correct
        public static void AssertLoginPasswordIsIncorrect(this LoginPage page)
        {
            Assert.AreEqual("Invalid login attempt.", page.IncorrectPassword.Text);
        }

        //Check if Login button is working and redirecting to Login Page
        public static void AssertLoginButtonIsWorking(this LoginPage page)
        {
            Assert.AreEqual("Log in", page.LoginButton.Text);
        }

        //Check if Register button is working and redirecting to Registration Page
        public static void AssertRegisterButtonIsWorking(this LoginPage page)
        {
            Assert.AreEqual("Register", page.RegisterButton.Text);
        }

        //Check if checkbox is selected and credentials are remembered
        public static void AssertCheckBoxIsSelected(this LoginPage page)
        {
            Assert.IsTrue(page.HelloMessage.Displayed);
        }

        //Check if SoftUniBlog button is working and redirecting to Home Page
        public static void AssertSoftUniBlogButtonIsWorking(this LoginPage page)
        {
            Assert.AreEqual("TestArticle12345-EditTitle", page.HomePage.Text);
        }

        //Check if copyright is present
        public static void AssertCopyrightIsPresent(this LoginPage page)
        {
            Assert.AreEqual("© 2017 - SoftUni Blog", page.Copyright.Text);
        }

        //Check "Create" button is not present
        public static void AssertCreateButtonIsNotPresent(this LoginPage page)
        {
            Assert.AreEqual("Register", page.RegisterButton.Text);
        }
    }
}

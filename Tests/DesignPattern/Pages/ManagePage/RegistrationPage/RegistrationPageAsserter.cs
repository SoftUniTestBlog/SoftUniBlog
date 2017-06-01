using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        //Registration page assertions by Tsvetomir Pavlov
        //Check if registration is successfull
        public static void AssertSuccessRegistration(this RegistrationPage page)
        {
            Assert.IsTrue(page.HelloMessage.Displayed);
        }

        //Check if email is entered
        public static void AssertEmailIsEntered(this RegistrationPage page)
        {
            Assert.AreEqual("The Email field is required.", page.EmailFieldRequired.Text);
        }

        //Check if correct email is entered
        public static void AssertIncorrectEmailIsEntered(this RegistrationPage page)
        {
            Assert.AreEqual("The Email field is not a valid e-mail address.", page.IncorrectEmail.Text);
        }

        //Check if full name is entered
        public static void AssertFullNameIsEntered(this RegistrationPage page)
        {
            Assert.AreEqual("The Full Name field is required.", page.FullNameEmpty.Text);
        }

        //Check if password is entered
        public static void AssertPasswordIsEntered(this RegistrationPage page)
        {
            Assert.AreEqual("The Password field is required.", page.PasswordEmpty.Text);
        }

        //Check if confirm password is entered
        public static void AssertConfirmPasswordIsEntered(this RegistrationPage page)
        {
            Assert.AreEqual("The password and confirmation password do not match.", page.ConfirmPasswordEmpty.Text);
        }

        //Check if confirm password match
        public static void AssertPasswordMatch(this RegistrationPage page)
        {
            Assert.AreEqual("The password and confirmation password do not match.", page.PasswordMismatch.Text);
        }

        //Check if SoftUniBlog button is working and redirecting to Home Page
        public static void AssertSoftUniBlogButtonIsWorking(this RegistrationPage page)
        {
            Assert.AreEqual("Edit title", page.HomePage.Text);
        }

        //Check if Login button is working and redirecting to Login Page
        public static void AssertLoginButtonIsWorking(this RegistrationPage page)
        {
            Assert.AreEqual("Log in", page.LoginPage.Text);
        }

        //Check if Register button is working and redirecting to Registration Page
        public static void AssertRegisterButtonIsWorking(this RegistrationPage page)
        {
            Assert.AreEqual("Register", page.RegistrationPageForm.Text);
        }
        
        //Check if copyright is present
        public static void AssertCopyrightIsPresent(this RegistrationPage page)
        {
            Assert.AreEqual("© 2017 - SoftUni Blog", page.Copyright.Text);
        }

        //Check "Create" button is not present
        public static void AssertCreateButtonIsNotPresent(this RegistrationPage page)
        {
            Assert.AreEqual("Register", page.RegisterButton.Text);
        }
    }
}

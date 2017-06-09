using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.ChangePasswordPage
{
    public static class ChangePasswordPageAsserter
    {
        //Check if current password is incorrect
        public static void AssertCurrentPasswordIsIncorrect(this ChangePasswordPage page)
        {
            Assert.AreEqual("Incorrect password.", page.IncorrectPasswordMessage.Text);
        }

        //Check if Confirm password is entered
        public static void AssertConfirmPasswordIsEntered(this ChangePasswordPage page)
        {
            Assert.AreEqual("The new password and confirmation password do not match.", page.IncorrectPasswordMessage.Text);
        }

        //Check if Confirm password is entered
        public static void AssertEnteredPasswordsAreMissmatching(this ChangePasswordPage page)
        {
            Assert.AreEqual("The new password and confirmation password do not match.", page.IncorrectPasswordMessage.Text);
        }

        //Check if button is working
        public static void AssertButtonIsWorking1(this ChangePasswordPage page)
        {
            Assert.AreEqual("The Current password field is required.", page.FirstError.Text);
        }

        //Check if button is working
        public static void AssertButtonIsWorking2(this ChangePasswordPage page)
        {
            Assert.AreEqual("The New password field is required.", page.SecondError.Text);
        }

        //Check if button is working
        public static void AssertChangePasswordIsSuccessfull(this ChangePasswordPage page)
        {
            Assert.AreEqual("Your password has been changed.", page.SuccessfullChangedPasswordMessage.Text);
        }
    }
}

